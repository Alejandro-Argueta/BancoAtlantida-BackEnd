using Microsoft.EntityFrameworkCore;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transactions>()
                .HasOne(t => t.TransactionType)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TransactionTypeID);

            modelBuilder.Entity<Transactions>()
                .HasOne(t => t.CreditCard)
                .WithMany(cc => cc.Transactions)
                .HasForeignKey(t => t.CreditCardID);

            modelBuilder.Entity<CreditCard>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CreditCards)
                .HasForeignKey(cc => cc.UserID);

            modelBuilder.Entity<CreditCard>()
               .Property(c => c.Limit)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditCard>()
               .Property(c => c.interestPercentage)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CreditCard>()
               .Property(c => c.percentageMinimumBalance)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transactions>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
