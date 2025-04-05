using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions
{
    public class CardNumberInvalidException : Exception
    {
        public CardNumberInvalidException() { }

        public CardNumberInvalidException(string cardNumber)
            : base("This card number:" + cardNumber + "is invalid") { }

        public CardNumberInvalidException(string cardNumber, Exception inner)
            : base("This card number:" + cardNumber + "is invalid" + inner) { }
    }

}
