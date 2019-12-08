using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Persistence
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task SavePaymentRecordAsync(PaymentRecord record)
        {
            using (PaymentDBContext context = new PaymentDBContext())
            {
                context.Payments.Add(record);
                await context.SaveChangesAsync();
            }
        }
    }
}
