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
    public class TransactionTypeController : Controller
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IMapper _mapper;
        public TransactionTypeController(ITransactionTypeRepository transactionTypeRepository, IMapper mapper)
        {
            _transactionTypeRepository = transactionTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TransactionType>))]
        public IActionResult GetTrasactionTypes()
        {
            var transactionTypes = _mapper.Map<List<TransactionTypeDto>>(_transactionTypeRepository.GetTransactionTypes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transactionTypes);
        }

        [HttpGet("id")]
        [ProducesResponseType(200, Type = typeof(TransactionType))]
        [ProducesResponseType(400)]
        public IActionResult GetTransactionType(int id)
        {
            if (!_transactionTypeRepository.TransactionTypeExist(id))
                return NotFound();

            var transactionType = _mapper.Map<TransactionTypeDto>(_transactionTypeRepository.GetTransactionType(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(transactionType);
        }
    }
}
