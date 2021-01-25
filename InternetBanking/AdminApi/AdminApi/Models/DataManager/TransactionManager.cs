﻿using AdminApi.Data;
using AdminApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Models.DataManager
{
    public class TransactionManager : DataRepository<Transaction, int>, ITransactionRepository
    {
        public TransactionManager(McbaContext context) : base(context)
        { }

        public IEnumerable<Transaction> GetTransactions(int accountNumber, DateTime? fromDate = null, DateTime? toDate = null)
        {
            //if (fromDate is null && toDate is null)
            //{
            //    return _context.Transactions.OrderByDescending(t => t.TransactionTimeUtc).Where(t => t.AccountNumber == accountNumber);
            //}else if(fromDate != null && toDate == null)
            //{

            //}
                return _context.Transactions.OrderByDescending(t => t.TransactionTimeUtc)
                                            .Where(t => t.AccountNumber == accountNumber 
                                                   && t.TransactionTimeUtc >= fromDate && t.TransactionTimeUtc <= toDate);
            
        }
    }
}
