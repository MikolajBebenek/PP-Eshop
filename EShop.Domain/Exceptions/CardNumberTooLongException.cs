using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions
{
    public class CardNumberTooLongException : Exception
    {
        public CardNumberTooLongException() { }

        public CardNumberTooLongException(string cardNumber)
            : base("This card number:" + cardNumber + "is too long") { }

        public CardNumberTooLongException(string cardNumber, Exception inner)
            : base("This card number:" + cardNumber + "is too long" + inner) { }
    }

}
