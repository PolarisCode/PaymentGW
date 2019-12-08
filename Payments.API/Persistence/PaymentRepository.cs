using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Payments.API.Persistence
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DbContextOptions _dbContextOptions;

        public PaymentRepository(string connectionString)
        {
            _dbContextOptions = new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public async Task SavePaymentRecordAsync(PaymentRecord record)
        {
            using (PaymentDBContext context = new PaymentDBContext(_dbContextOptions))
            {
                context.Payments.Add(record);

                await context.SaveChangesAsync();
            }
        }
    }
}
