using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCardStatus.Models
{
    public class CreditCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Number { get; set; }

        [Required]
        public decimal Limit { get; set; }
        public decimal interestPercentage { get; set; }
        public decimal percentageMinimumBalance { get; set; }

        public int UserID { get; set; }

        public Users User { get; set; }

        public ICollection<Transactions> Transactions { get; set; }
    }
}
