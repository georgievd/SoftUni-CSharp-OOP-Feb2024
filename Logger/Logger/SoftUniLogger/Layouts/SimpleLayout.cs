using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(Message message)
        {
            return $"{message.DateTime} - {message.LogEntryLevel} - {message.LogMessage}";
        }
    }
}
