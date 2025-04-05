using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions
{
    public class CardNumberTooShortException : Exception
    {
        public CardNumberTooShortException() { }

        public CardNumberTooShortException(string cardNumber)
            : base("This card number:" + cardNumber + "is too short") { }

        public CardNumberTooShortException(string cardNumber, Exception inner)
            : base("This card number:" + cardNumber + "is too short" + inner) { }
    }

}
