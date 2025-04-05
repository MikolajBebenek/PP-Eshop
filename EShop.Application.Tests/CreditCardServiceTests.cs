using EShop.Application;
using EShop.Domain.Exceptions;
using System;
using Xunit;
namespace EShop.Application.Tests
{
    public class CreditCardServiceTests
    {
        CreditCardService _creditCardService = new CreditCardService();

        [Theory]
        [InlineData("4024-0071-6540-1778", true)] // Visa
        [InlineData("5555555555554444", true)] // MasterCard
        [InlineData("345-470-784-783-010", true)] // American Express
        [InlineData("6011111111111117", true)] // Discover
        [InlineData("3566002020360505", true)] // JCB
        [InlineData("30569309025904", true)] // Diners Club
        [InlineData("5018000000000009", true)] // Maestro

        public void ValidateCard_CardNumber_MatchesPattern(string cardNumber, bool expected)
        {
            var result = _creditCardService.ValidateCard(cardNumber);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("4024-0071-6540-1778", "Visa")]
        [InlineData("5555555555554444", "MasterCard")]
        [InlineData("345-470-784-783-010", "American Express")]
        [InlineData("6011111111111117", "Discover")]
        [InlineData("3566002020360505", "JCB")]
        [InlineData("30569309025904", "Diners Club")]
        [InlineData("5018000000000009", "Maestro")]

        public void GetCardType_CardNumber_MatchesName(string cardNumber, string expected)
        {
            var result = _creditCardService.GetCardType(cardNumber);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("123")]
        public void ValidateCard_TooShort_ThrowsException(string cardNumber)
        {
            Assert.Throws<CardNumberTooShortException>(() => _creditCardService.ValidateCard(cardNumber));
        }

        [Theory]
        [InlineData("1234567890123456789012345")]
        public void ValidateCard_TooLong_ThrowsException(string cardNumber)
        {
            Assert.Throws<CardNumberTooLongException>(() => _creditCardService.ValidateCard(cardNumber));
        }
    }
}
