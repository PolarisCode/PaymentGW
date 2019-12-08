using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Payments.API.Persistence
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext()
        {
        }

        public PaymentDBContext(DbContextOptions options) : base(options) { }

        public DbSet<PaymentRecord> Payments { get; set; } 
    }
}
