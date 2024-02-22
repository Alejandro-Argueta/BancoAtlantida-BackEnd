using System;
using System.Linq;
using WebApiCardStatus.Data;
using WebApiCardStatus.Models;

namespace WebApiCardStatus
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            // Verificar si ya hay datos en la base de datos
            if (dataContext.Users.Any() || dataContext.CreditCards.Any() || dataContext.Transactions.Any() || dataContext.TransactionTypes.Any())
            {
                return; // La base de datos ya está poblada
            }

            // Agregar usuarios
            var user1 = new Users { Name = "John", LastName = "Doe" };
            var user2 = new Users { Name = "Jane", LastName = "Smith" };
            dataContext.Users.AddRange(user1, user2);
            dataContext.SaveChanges();

            // Agregar tarjetas de crédito
            var creditCard1 = new CreditCard { Number = "1111222233334444", Limit = 5000, User = user1 };
            var creditCard2 = new CreditCard { Number = "5555666677778888", Limit = 10000, User = user2 };
            dataContext.CreditCards.AddRange(creditCard1, creditCard2);
            dataContext.SaveChanges();

            // Agregar tipos de transacción
            var transactionType1 = new TransactionType { Name = "Compra" };
            var transactionType2 = new TransactionType { Name = "Pago A" };
            dataContext.TransactionTypes.AddRange(transactionType1, transactionType2);
            dataContext.SaveChanges();

            // Agregar transacciones
            var transaction1 = new Transactions { Date = DateTime.Now, Description = "Compra de alimentos", Amount = 100, TransactionType = transactionType1, CreditCard = creditCard1 };
            var transaction2 = new Transactions { Date = DateTime.Now, Description = "Pago de facturasssssssss", Amount = 50, TransactionType = transactionType2, CreditCard = creditCard2};
            dataContext.Transactions.AddRange(transaction1, transaction2);
            dataContext.SaveChanges();
        }

    }
}
