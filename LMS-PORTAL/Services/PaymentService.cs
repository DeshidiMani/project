using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;

namespace LMSCapstone.Services
{
    public interface IPaymentService
    {
        Task<string> ProcessPaymentAsync(Payment payment);
    }

    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<string> ProcessPaymentAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
            // TODO: Integrate with Stripe API for secure payment processing.
            return "https://dummy.stripe.payment.link";
        }
    }
}
