using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string phoneNumber;
        private string url;

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                if (!value.All(pn => char.IsDigit(pn)))
                {
                    throw new ArgumentException("Invalid number!");
                }
                this.phoneNumber = value;
            }
        }

        public string URL
        {
            get => this.url;
            set
            {
                if (value.Any(u => char.IsDigit(u)))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                this.url = value;
            }
        }

        public string Call()
        {
            return $"Calling... {this.PhoneNumber}";
        }

        public string Browse()
        {
            return $"Browsing: {this.URL}!";
        }
    }
}
