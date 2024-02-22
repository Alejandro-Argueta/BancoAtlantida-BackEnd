using WebApiCardStatus.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiCardStatus.Interfaces;

namespace WebApiCardStatus.Data
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly DataContext _context;

        public CreditCardRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<CreditCard> GetCreditCards()
        {
            return _context.CreditCards
                .Include(cc => cc.User)
                .Include(cc => cc.Transactions)
                .OrderBy(p => p.Id);
        }

        public CreditCard GetCreditCard(int id)
        {
            return _context.CreditCards
                .Include(cc => cc.User)
                .Include(cc => cc.Transactions)
                    .ThenInclude(t => t.TransactionType)
                .FirstOrDefault(p => p.Id == id);
        }

        public bool CreditCardExist(int id)
        {
            return _context.CreditCards.Any(p => p.Id == id);
        }

        public void DeleteCreditCard(int id)
        {
            var cardToDelete = _context.CreditCards.Find(id);
            if (cardToDelete != null)
            {
                _context.CreditCards.Remove(cardToDelete);
                _context.SaveChanges();
            }
        }
    }
}
