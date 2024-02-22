namespace WebApiCardStatus.Dto
{
    public class CreditCardDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public decimal Limit { get; set; }

        public decimal interestPercentage { get; set; }
        public decimal percentageMinimumBalance { get; set; }

        public UsersDto User { get; set; }

        public List<TransactionsDto> Transactions { get; set; }
    }
}
