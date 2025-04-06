using EShop.Application;
using EShop.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace EShopService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("{cardNumber}")]
        public IActionResult Get(string cardNumber)
        {
            try
            {
                _creditCardService.ValidateCard(cardNumber);
                var provider = _creditCardService.GetCardType(cardNumber);
                return Ok(new { cardProvider = provider });
            }
            catch (CardNumberTooLongException ex)
            {
                return StatusCode((int)HttpStatusCode.RequestUriTooLong, new { error = ex.Message, code = (int)HttpStatusCode.RequestUriTooLong });
            }
            catch (CardNumberTooShortException ex)
            {
                return BadRequest(new { error = ex.Message, code = (int)HttpStatusCode.BadRequest });
            }
            catch (CardNumberInvalidException ex)
            {
                return BadRequest(new { error = ex.Message, code = (int)HttpStatusCode.BadRequest });
            }
        }
    }
}
