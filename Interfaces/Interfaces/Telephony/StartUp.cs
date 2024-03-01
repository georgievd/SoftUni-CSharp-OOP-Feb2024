using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            var phones = ReadInput();
            var urls = ReadInput();

            CallAllThePhones(phones);

            foreach (var url in urls)
            {
                if (IsUrlValid(url))
                {
                    SmartPhone smartPhone = new SmartPhone();
                    smartPhone.Browse(url);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }

        private static bool IsUrlValid(string url)
        {
            return !url.Any(char.IsDigit);
        }

        private static void CallAllThePhones(string[] phones)
        {
            foreach (var phoneNumber in phones)
            {
                if (IsValidPhoneNumber(phoneNumber))
                {
                    ICaller phone;
                    if (phoneNumber.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        phone = new SmartPhone();
                    }

                    phone.Call(phoneNumber);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
