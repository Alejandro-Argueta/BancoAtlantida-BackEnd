using Microsoft.AspNetCore.Mvc;
using WebApiCardStatus.Data;
using WebApiCardStatus.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApiCardStatus.Models;
using System.Collections.Generic;
using AutoMapper;
using WebApiCardStatus.Dto;
using WebApiCardStatus.Repository;

namespace WebApiCardStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly ITransactionsRepository _transactionRepository;
        private readonly IMapper _mapper;
        public CreditCardController(ICreditCardRepository creditCardRepository, ITransactionsRepository transactionRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CreditCardDto>))]
        public IActionResult GetCreditCards()
        {
            var creditCards = _creditCardRepository.GetCreditCards().ToList();
            var creditCardDtos = _mapper.Map<List<CreditCardDto>>(creditCards);

            foreach (var creditCardDto in creditCardDtos)
            {
                creditCardDto.User = _mapper.Map<UsersDto>(creditCardDto.User);
                creditCardDto.Transactions = _mapper.Map<List<TransactionsDto>>(creditCardDto.Transactions);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(creditCardDtos);
        }




        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CreditCard))]
        [ProducesResponseType(400)]
        public IActionResult GetCreditCard(int id)
        {
            if (!_creditCardRepository.CreditCardExist(id))
                return NotFound();

            var creditCard = _creditCardRepository.GetCreditCard(id);
            if (creditCard.Transactions != null && creditCard.Transactions.Any())
            {
                foreach (var tran in creditCard.Transactions)
                {
                    var transaction = _mapper.Map<Transactions>(tran);

                    if (transaction.TransactionType != null)
                    {
                        transaction.TransactionType = _mapper.Map<TransactionType>(transaction.TransactionType);
                    }
                    creditCard.Transactions.Add(transaction);
                }
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(creditCard);
        }

    }
}
