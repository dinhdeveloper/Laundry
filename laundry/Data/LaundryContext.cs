using System;
using laundry.Models;
using Microsoft.EntityFrameworkCore;

namespace laundry.Data
{
    public class LaundryContext : DbContext
    {
        public LaundryContext(DbContextOptions<LaundryContext> options) : base(options)
        {

        }
        public virtual DbSet<CustomerEntities> Customer { get; set; }
        public virtual DbSet<BillEntities> Bills { get; set; }
        public virtual DbSet<DeliveryEntities> Deliveries { get; set; }
        public virtual DbSet<LaudryTypeEnitites> LaudryTypes { get; set; }
        public virtual DbSet<OrderEntities> Orders { get; set; }
    }
}
