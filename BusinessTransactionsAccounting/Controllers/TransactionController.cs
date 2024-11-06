using BusinessTransactionsAccounting.Models;
using BusinessTransactionsAccounting.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BusinessTransactionsAccounting.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AccountingService _accountingService;

        public TransactionController(AccountingService accountingService)
        {
            _accountingService = accountingService;
        }

        [HttpGet]
        public IActionResult Create(int accountId)
        {
            ViewBag.AccountId = accountId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.Date = DateTime.Now;
                _accountingService.AddTransaction(transaction);
                return RedirectToAction("Details", "Account", new { id = transaction.AccountId });
            }
            return View(transaction);
        }
    }
}
