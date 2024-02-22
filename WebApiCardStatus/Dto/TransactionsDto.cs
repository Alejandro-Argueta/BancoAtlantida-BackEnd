using System.ComponentModel.DataAnnotations;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Dto
{
    public class TransactionsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

    }
}
