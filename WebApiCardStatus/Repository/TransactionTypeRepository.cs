using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCardStatus.Data;
using WebApiCardStatus.Interfaces;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly DataContext _context;

        public TransactionTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void AddTransactionType(TransactionType transactionType)
        {
            if (transactionType == null)
            {
                throw new ArgumentNullException(nameof(transactionType));
            }

            _context.TransactionTypes.Add(transactionType);
            _context.SaveChanges();
        }

        public void DeleteTransactionType(int id)
        {
            var transactionTypeToDelete = _context.TransactionTypes.Find(id);
            if (transactionTypeToDelete != null)
            {
                _context.TransactionTypes.Remove(transactionTypeToDelete);
                _context.SaveChanges();
            }
        }

        public TransactionType GetTransactionType(int id)
        {
            return _context.TransactionTypes.FirstOrDefault(t => t.Id == id);
        }

        public TransactionType GetTransactionType(string name)
        {
            return _context.TransactionTypes.FirstOrDefault(t => t.Name == name);
        }

        public ICollection<TransactionType> GetTransactionTypes()
        {
            return _context.TransactionTypes.OrderBy(t => t.Id).ToList();
        }

        public bool TransactionTypeExist(int id)
        {
            return _context.TransactionTypes.Any(t => t.Id == id);
        }

        public void UpdateTransactionType(TransactionType transactionType)
        {
            if (transactionType == null)
            {
                throw new ArgumentNullException(nameof(transactionType));
            }

            var existingTransactionType = _context.TransactionTypes.FirstOrDefault(u => u.Id == transactionType.Id);
            if (existingTransactionType != null)
            {
                existingTransactionType.Name = transactionType.Name;
                _context.SaveChanges();
            }
        }
    }
}
