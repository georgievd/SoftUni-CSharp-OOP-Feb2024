using System.Xml.Linq;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format(Message message)
        {
            XElement logEntry = new XElement("log",
                new XElement("date", message.DateTime),
                new XElement("level", message.LogEntryLevel),
                new XElement("message", message.LogMessage));
            return logEntry.ToString();
        }
    }
}
