using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiCardStatus.Dto;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IMapper _mapper;

        public TransactionTypeController(ITransactionTypeRepository transactionTypeRepository, IMapper mapper)
        {
            _transactionTypeRepository = transactionTypeRepository ?? throw new ArgumentNullException(nameof(transactionTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TransactionTypeDto>))]
        public IActionResult GetTrasactionTypes()
        {
            var transactionTypes = _mapper.Map<List<TransactionTypeDto>>(_transactionTypeRepository.GetTransactionTypes());
            return Ok(transactionTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TransactionTypeDto))]
        [ProducesResponseType(404)]
        public IActionResult GetTransactionType(int id)
        {
            var transactionType = _transactionTypeRepository.GetTransactionType(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            var transactionTypeDto = _mapper.Map<TransactionTypeDto>(transactionType);
            return Ok(transactionTypeDto);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddTransactionType(TransactionTypeDto transactionTypeDto)
        {
            if (transactionTypeDto == null)
            {
                return BadRequest("TransactionTypeDto object is null");
            }

            var transactionType = _mapper.Map<TransactionType>(transactionTypeDto);
            _transactionTypeRepository.AddTransactionType(transactionType);

            return CreatedAtAction(nameof(GetTransactionType), new { id = transactionType.Id }, transactionType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTransactionType(int id, [FromBody] TransactionTypeDto transactionTypeDto)
        {
            if (transactionTypeDto == null || id != transactionTypeDto.Id)
            {
                return BadRequest("Invalid TransactionTypeDto object or ID mismatch");
            }

            if (!_transactionTypeRepository.TransactionTypeExist(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionTypeToUpdate = _mapper.Map<TransactionType>(transactionTypeDto);
            _transactionTypeRepository.UpdateTransactionType(transactionTypeToUpdate);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTransactionType(int id)
        {
            var transactionType = _transactionTypeRepository.GetTransactionType(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            _transactionTypeRepository.DeleteTransactionType(id);

            return NoContent();
        }
    }
}
