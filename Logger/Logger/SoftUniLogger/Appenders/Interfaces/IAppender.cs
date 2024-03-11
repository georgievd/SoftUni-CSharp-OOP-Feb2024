using SoftUniLogger.Models;

namespace SoftUniLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        void Append(Message message);
        LogEntryLevel LogLevel { get; set; }
    }
}
