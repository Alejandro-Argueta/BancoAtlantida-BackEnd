using WebApiCardStatus.Models;

namespace WebApiCardStatus.Interfaces
{
    public interface ICreditCardRepository
    {
        IQueryable<CreditCard> GetCreditCards();

        CreditCard GetCreditCard(int id);
        bool CreditCardExist(int id);
        void DeleteCreditCard(int id);
    }
}
