using SoftUniLogger.Models;

namespace SoftUniLogger.Layouts.Interfaces
{
    public interface ILayout
    {
        string Format(Message message);
    }
}
