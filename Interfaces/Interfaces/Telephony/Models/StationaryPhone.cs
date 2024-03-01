using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICaller
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
