using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout _layout;
        public string FilePath { get; set; } 
            = $"..\\..\\..\\{DateTime.Now:yyyyMMddhhmmss}.txt";

        public FileAppender(ILayout layout)
        {
            _layout = layout;
        }

        public FileAppender(ILayout layout, string filePath) 
            : this(layout)
        {
            FilePath = filePath;
        }

        public LogEntryLevel LogLevel { get; set; } = 0;

        public void Append(Message message)
        {
            string formattedLogEntry = _layout.Format(message);
            try
            {
                // File manages the streams for us
                File.AppendAllText(FilePath, formattedLogEntry + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
