using Microsoft.EntityFrameworkCore;
using WebApiCardStatus.Data;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly DataContext _context;
        public TransactionTypeRepository(DataContext context)
        {
            _context = context;
        }
        public TransactionType GetTransactionType(int id)
        {
            return _context.TransactionTypes.Where(t => t.Id == id).FirstOrDefault();
        }

        public TransactionType GetTransactionType(string name)
        {
            return _context.TransactionTypes.Where(t => t.Name == name).FirstOrDefault();
        }

        public ICollection<TransactionType> GetTransactionTypes()
        {
            return _context.TransactionTypes.OrderBy(t => t.Id).ToList();
        }

        public bool TransactionTypeExist(int id)
        {
            return _context.TransactionTypes.Any(p => p.Id == id);
        }
    }
}
