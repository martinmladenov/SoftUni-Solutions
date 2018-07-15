namespace P01_BillsPaymentSystem.Data
{
    using EntityConfig;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext() { }

        public BillsPaymentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
        }
    }
}
