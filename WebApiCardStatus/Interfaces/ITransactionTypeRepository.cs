using WebApiCardStatus.Models;

namespace WebApiCardStatus.Interfaces
{
    public interface ITransactionTypeRepository
    {
        ICollection<TransactionType> GetTransactionTypes();

        TransactionType GetTransactionType(int id);
        TransactionType GetTransactionType(string name);
        bool TransactionTypeExist(int id);

        void AddTransactionType(TransactionType transactionType);
        void UpdateTransactionType(TransactionType transactionType);
        void DeleteTransactionType(int id);
    }
}
