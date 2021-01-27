﻿using AdminApp.AutoGeneratedModel;
using AdminApp.Filters;
using AdminApp.Interfaces;
using AdminApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{

    [AuthorizeAdmin]
    [Route("/Mcba/ViewTransactions")]
    public class TransactionController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ICustomerService customerService, ITransactionService transactionService,
                                     ILogger<TransactionController> logger)
        {
            _customerService = customerService;
            _transactionService = transactionService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync().ConfigureAwait(false);
            return View(new TransactionViewModel
            {
                Transactions = transactions
            });
        }

        //public async Task<IActionResult> Index(TransactionViewModel viewModel)
        //{
        //    var customer = await GetCustomerAsync(viewModel.CustomerID).ConfigureAwait(false);

        //    // Get accounts for customer
        //    viewModel.Accounts = customer.Accounts.ToList();
        //    var transactions = new List<Transaction>();
        //    foreach (var account in viewModel.Accounts)
        //    {
        //        if (account != null)
        //        {
        //            var transactionList = await GetTransactionsAsync(account.AccountNumber).ConfigureAwait(false);
        //            transactions.Concat(transactionList);
        //        }
        //    }
        //    viewModel.Transactions = transactions;
        //    return View(viewModel);
        //}





    }
}
