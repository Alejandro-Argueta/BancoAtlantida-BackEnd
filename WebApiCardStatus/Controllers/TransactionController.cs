using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCardStatus.Dto;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;
using WebApiCardStatus.Repository;

namespace WebApiCardStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionsRepository _transactionRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionsRepository transactionRepository,
            ITransactionTypeRepository transactionTypeRepository,
            ICreditCardRepository creditCardRepository,
        IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _transactionTypeRepository = transactionTypeRepository;
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Transactions>))]
        public IActionResult GetTransactions()
        {
            var transactions = _mapper.Map<List<TransactionsDto>>(_transactionRepository.GetTransactions());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transactions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Transactions))]
        [ProducesResponseType(400)]
        public IActionResult GetTransaction(int id)
        {
            if (!_transactionRepository.TransactionExist(id))
                return NotFound();

            var transaction = _mapper.Map<TransactionsDto>(_transactionRepository.GetTransaction(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transaction);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTransaction([FromQuery] int transactionId, [FromQuery] int creditCardId, [FromBody] TransactionsDto transactionCreate)
        {
            if (transactionCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionMap = _mapper.Map<Transactions>(transactionCreate);

            transactionMap.TransactionType = (TransactionType)_transactionTypeRepository.GetTransactionType(transactionId);
            transactionMap.CreditCard = (CreditCard)_creditCardRepository.GetCreditCard(creditCardId);

            if (!_transactionRepository.CreateTransaction(transactionMap))
            {
                ModelState.AddModelError("", "Error normal");
                return StatusCode(500, ModelState);
            }

            return Ok("Transaccion Realizada");

        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTransactions(int id, [FromBody] TransactionsDto transactionsDto)
        {
            if (transactionsDto == null || id != transactionsDto.Id)
            {
                return BadRequest("Invalid TransactionsDto object or ID mismatch");
            }

            if (!_transactionRepository.TransactionExist(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionsToUpdate = _mapper.Map<Transactions>(transactionsDto);
            _transactionRepository.UpdateTransactions(transactionsToUpdate);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTransactions(int id)
        {
            var transactions = _transactionRepository.GetTransaction(id);
            if (transactions == null)
            {
                return NotFound();
            }

            _transactionRepository.DeleteTransactions(id);

            return NoContent();
        }
    }
}
