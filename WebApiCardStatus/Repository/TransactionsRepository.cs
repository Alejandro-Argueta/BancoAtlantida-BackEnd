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

        public bool CreateTransaction(Transactions transactions)
        {

            _context.Add(transactions);
         
            return Save();
        }

        public Transactions GetTransaction(int id)
        {
            return _context.Transactions.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<Transactions> GetTransactions()
        {
            return _context.Transactions.OrderBy(t => t.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransactionExist(int id)
        {
            return _context.Transactions.Any(t => t.Id == id);
        }
    }
}
