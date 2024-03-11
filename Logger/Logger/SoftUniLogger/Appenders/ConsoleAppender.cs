using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout _layout;

        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }
        public LogEntryLevel LogLevel { get; set; } = 0;

        public void Append(Message message)
        {
            Console.WriteLine(_layout.Format(message));
        }


    }
}
