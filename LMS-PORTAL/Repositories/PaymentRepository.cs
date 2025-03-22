using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Data;

namespace LMSCapstone.Repositories
{
    public interface IPaymentRepository
    {
        Task AddAsync(Payment payment);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly LMSDbContext _context;
        public PaymentRepository(LMSDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
    }
}
