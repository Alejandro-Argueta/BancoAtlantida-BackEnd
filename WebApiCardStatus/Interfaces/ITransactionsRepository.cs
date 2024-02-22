using WebApiCardStatus.Models;

namespace WebApiCardStatus.Interfaces
{
    public interface ITransactionsRepository
    {

        ICollection<Transactions> GetTransactions();
        Transactions GetTransaction(int id);
        bool TransactionExist(int id);
        bool CreateTransaction(Transactions transactions);
        bool Save();
        void UpdateTransactions(Transactions transactions);
        void DeleteTransactions(int id);
    }
}
