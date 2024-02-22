using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCardStatus.Models
{
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int TransactionTypeID { get; set; }
        public TransactionType TransactionType { get; set; }

        public int CreditCardID { get; set; }
        public CreditCard CreditCard { get; set; }

    }
}
