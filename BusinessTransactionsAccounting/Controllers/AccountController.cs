using BusinessTransactionsAccounting.Models;
using BusinessTransactionsAccounting.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTransactionsAccounting.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountingService _accountingService;

        public AccountController(AccountingService accountingService)
        {
            _accountingService = accountingService;
        }

        public IActionResult Index()
        {
            var accounts = _accountingService.GetAllAccounts();
            return View(accounts);
        }

        public IActionResult Details(int id)
        {
            var account = _accountingService.GetAccountById(id);
            if (account == null) return NotFound();
            var transactions = _accountingService.GetTransactions(id);
            ViewBag.Transactions = transactions;
            return View(account);
        }
    }
}
