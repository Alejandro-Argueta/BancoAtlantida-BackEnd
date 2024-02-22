using WebApiCardStatus.Data;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Repository
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly DataContext _context;

        public TransactionsRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTransaction(Transactions transaction)
        {
            _context.Add(transaction);
            return Save();
        }

        public void DeleteTransactions(int id)
        {
            var transactionToDelete = _context.Transactions.Find(id);
            if (transactionToDelete != null)
            {
                _context.Transactions.Remove(transactionToDelete);
                _context.SaveChanges();
            }
        }

        public Transactions GetTransaction(int id)
        {
            return _context.Transactions.Find(id);
        }

        public ICollection<Transactions> GetTransactions()
        {
            return _context.Transactions.OrderBy(t => t.Id).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool TransactionExist(int id)
        {
            return _context.Transactions.Any(t => t.Id == id);
        }

        public void UpdateTransactions(Transactions transactions)
        {
            if (transactions == null)
            {
                throw new ArgumentNullException(nameof(transactions));
            }

            var existingTransaction = _context.Transactions.FirstOrDefault(u => u.Id == transactions.Id);
            if (existingTransaction != null)
            {
                existingTransaction.Date = transactions.Date;
                existingTransaction.Description = transactions.Description;
                existingTransaction.Amount = transactions.Amount;
                _context.SaveChanges();
            }
        }

    }
}
