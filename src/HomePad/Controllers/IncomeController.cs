using ApplicationCore.Entities;
using HomePad.Models;
using Infrastructure.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomePad.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public IncomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            Repository<Income> repository = new Repository<Income>();
            IEnumerable<Income> incomes = repository.GetAll();
            List<IncomeVM> incomeVMs = new List<IncomeVM>();
        
            foreach (Income income in incomes)
            {
                IncomeVM incomeVM = new IncomeVM();
                incomeVM.Id = income.Id;
                incomeVM.AccountHeadId = income.AccountHeadId;
                incomeVM.Title = income.Title;
                incomeVM.TransactionDate = income.TransactionDate;
                incomeVM.LastUpdatedBy = income.LastUpdatedBy;
                incomeVM.LastUpdatedDate = income.LastUpdatedDate;
                incomeVM.CreateDate = income.CreateDate;
                incomeVM.Note = income.Note;

            }

            return View(incomeVMs);
        }

        public IActionResult Create()
        {
            IncomeVM incomeVM = new IncomeVM();
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
            ViewBag.accountHeads = accountHeadVMs;
            return View(incomeVM); 

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncomeVM incomeVM)
        {
            if (ModelState.IsValid)
            {

            }
            return View(incomeVM);
        }
    }
}
