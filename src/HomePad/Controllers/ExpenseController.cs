using ApplicationCore.Entities;
using HomePad.Models;
using Infrastructure.Data_Access;
using Microsoft.AspNetCore.Mvc;

namespace HomePad.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IConfiguration _configuration;
        public ExpenseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            Repository<Expense> repository = new Repository<Expense>();
            IEnumerable<Expense> expenses = repository.GetAll();
            List<ExpenseVM> expenseVMs = new List<ExpenseVM>();
            Repository<AccountHead> repo = new Repository<AccountHead>();
            foreach (Expense expense in expenses)
            {

                ExpenseVM expenseVM = new ExpenseVM();
                expenseVM.Id = expense.Id;
                expenseVM.AccountHeadId = expense.AccountHeadId;

                AccountHead accHead = repo.GetById(expenseVM.AccountHeadId);

                expenseVM.AccountHeadName = accHead.Name;

                expenseVM.Title = expense.Title;
                expenseVM.TransactionDate = expense.TransactionDate;
                expenseVM.LastUpdatedBy = expense.LastUpdatedBy;
                expenseVM.LastUpdatedDate = DateTime.Now;
                expenseVM.CreateDate = expense.CreateDate;
                expenseVM.Attachment = expense.Attachment;
                expenseVM.Note = expense.Note;
                expenseVMs.Add(expenseVM);
            }
            return View(expenseVMs);
        }

        public IActionResult Create() 
        {
            ExpenseVM expenseVM = new ExpenseVM();
            List<AccountHeadVM> aHVM = GetAccountHeadVM();
            ViewBag.accountHeads = aHVM;
            return View(expenseVM);

        }

        private List<AccountHeadVM> GetAccountHeadVM()
        {
            Repository<AccountHead> repository = new Repository<AccountHead>();
            IEnumerable<AccountHead> accountHeads = repository.GetAll();
            List<AccountHeadVM> accountHeadVMs = new List<AccountHeadVM>();
            foreach (AccountHead accountHead in accountHeads)
            {
                AccountHeadVM accountHeadVM = new AccountHeadVM();
                accountHeadVM.Id = accountHead.Id;
                accountHeadVM.Name = accountHead.Name;
                accountHeadVMs.Add(accountHeadVM);
            }
            return accountHeadVMs;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseVM expenseVM)
        {
            if (ModelState.IsValid)
            {
                Repository<Expense> repository = new Repository<Expense>();
                Expense expense = new Expense();
                expense.Id = expenseVM.Id;
                expense.AccountHeadId = expenseVM.AccountHeadId;
                expense.Title = expenseVM.Title;
                expense.Amount = expenseVM.Amount;
                expense.Attachment = expenseVM.Attachment;
                expense.LastUpdatedDate = DateTime.Now;
                expense.LastUpdatedBy = expenseVM.LastUpdatedBy;
                expense.Note = expenseVM.Note;
                repository.Insert(expense);
                repository.Save();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.accountHeads = GetAccountHeadVM();
            return View(expenseVM);
        }
    }
}
