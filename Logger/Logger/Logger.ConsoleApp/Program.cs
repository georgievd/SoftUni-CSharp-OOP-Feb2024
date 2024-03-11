using System.Globalization;
using SoftUniLogger.Appenders;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Factories;
using SoftUniLogger.Layouts;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Loggers.Interfaces;
using SoftUniLogger.Models;

namespace Logger.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InitializeWithoutPatterns();
            //var consoleLogger = InitializeWithFactory();

            int numberOfAppenders = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ILayout layout = new SimpleLayout();

                switch (appenderData[1])
                {
                    case "SimpleLayout":
                        layout = new SimpleLayout();
                        break;
                    case "XmlLayout":
                        layout = new XmlLayout();
                        break;
                    default:
                        Console.WriteLine("Invalid layout.");
                        break;
                }

                IAppender appender = new ConsoleAppender(layout);
                switch (appenderData[0])
                {
                    case "ConsoleAppender":
                        appender = new ConsoleAppender(layout);
                        break;
                    case "FileAppender":
                        appender = new FileAppender(layout);
                        break;
                }

                if (appenderData.Length == 3)
                {
                    appender.LogLevel = appenderData[2] switch
                    {
                        "INFO" => LogEntryLevel.Info,
                        "WARNING" => LogEntryLevel.Warning,
                        "ERROR" => LogEntryLevel.Error,
                        "CRITICAL" => LogEntryLevel.Critical,
                        "FATAL" => LogEntryLevel.Fatal,
                        _ => appender.LogLevel
                    };
                }

                appenders.Add(appender);

            }

            ILogger logger = new SoftUniLogger.Loggers.Logger(appenders);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                switch (data[0])
                {
                    case "INFO":
                        logger.Info(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "WARNING":
                        logger.Warning(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "ERROR":
                        logger.Error(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "CRITICAL":
                        logger.Critical(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "FATAL":
                        logger.Fatal(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                }
            }    
        }

        private static void InitializeWithoutPatterns()
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender fileAppender = new FileAppender(xmlLayout);

            consoleAppender.LogLevel = LogEntryLevel.Critical;

            ILogger logger = new SoftUniLogger.Loggers.Logger(fileAppender);
            logger.AddAppender(consoleAppender);
        }

        private static ILogger InitializeWithFactory()
        {
            var loggerFactory = new LoggerFactory();
            ILogger consoleLogger = loggerFactory.CreateLogger("console");
            ILogger fileLogger = loggerFactory.CreateLogger("file");
            return consoleLogger;
        }
    }
}
