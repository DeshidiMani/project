using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/payments")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] Payment payment)
        {
            var paymentLink = await _paymentService.ProcessPaymentAsync(payment);
            if (!string.IsNullOrEmpty(paymentLink))
                return Ok(new { success = true, message = (string)null, data = new { PaymentLink = paymentLink } });
            return BadRequest(new { success = false, message = "Payment processing failed", data = (object)null });
        }
    }
}
