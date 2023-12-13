using ApplicationCore.Entities;
using HomePad.Models;
using Infrastructure.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            Repository<AccountHead> repo = new Repository<AccountHead>();
           

            foreach (Income income in incomes)
            {
                
                IncomeVM incomeVM = new IncomeVM();
                incomeVM.Id = income.Id;
                incomeVM.AccountHeadId = income.AccountHeadId;

                AccountHead accHead = repo.GetById(incomeVM.AccountHeadId);

                incomeVM.AccountHeadName = accHead.Name;
                
                incomeVM.Title = income.Title;
                incomeVM.TransactionDate = income.TransactionDate;
                incomeVM.LastUpdatedBy = income.LastUpdatedBy;
                incomeVM.LastUpdatedDate = income.LastUpdatedDate;
                incomeVM.CreateDate = income.CreateDate;
                incomeVM.Attachment = income.Attachment;
                incomeVM.Note = income.Note;
                incomeVMs.Add(incomeVM);
            }

            return View(incomeVMs);
        }

        public IActionResult Create()
        
        {
            IncomeVM incomeVM = new IncomeVM();
            List<AccountHeadVM> aHVM = GetAccountHeadVM();
            ViewBag.accountHeads = aHVM;
            return View(incomeVM); 

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
        public async Task<IActionResult> Create(IncomeVM incomeVM)
        {
            if (ModelState.IsValid)
            {
                Repository<Income> repository = new Repository<Income>();
                Income income = new Income();
                income.Id = incomeVM.Id;
                income.AccountHeadId = incomeVM.AccountHeadId;
                income.Title = incomeVM.Title;
                income.LastUpdatedDate = incomeVM.LastUpdatedDate;
                income.Amount = incomeVM.Amount;
                income.Attachment = incomeVM.Attachment;
                income.LastUpdatedDate = DateTime.Now;
                income.LastUpdatedBy = string.Empty;
                income.Note = incomeVM.Note;
                repository.Insert(income);
                repository.Save();
                return RedirectToAction(nameof(Index));

            }
            ViewBag.accountHeads = GetAccountHeadVM();
            return View(incomeVM);
        }

        public IActionResult Edit(int Id)
        {
            IncomeVM incomeVM = new IncomeVM();
            Repository<Income> repository = new Repository<Income>();
            Income income = repository.GetById(Id);
            incomeVM.Id = income.Id;
            incomeVM.AccountHeadId = income.AccountHeadId;
            incomeVM.Title = income.Title;
            incomeVM.LastUpdatedDate = income.LastUpdatedDate;
            incomeVM.Amount = income.Amount;
            incomeVM.Attachment = income.Attachment;
            incomeVM.LastUpdatedDate = DateTime.Now;
            incomeVM.LastUpdatedBy = income.LastUpdatedBy;
            incomeVM.Note = income.Note;

            return View(incomeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IncomeVM incomeVM)
        {
            if (id != incomeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                Repository<Income> repository = new Repository<Income>();
                Income income = new Income();
                income.Id = incomeVM.Id;
                income.AccountHeadId = incomeVM.AccountHeadId;
                income.Title = incomeVM.Title;
                income.LastUpdatedDate = incomeVM.LastUpdatedDate;
                income.Amount = incomeVM.Amount;
                income.Attachment = incomeVM.Attachment;
                income.LastUpdatedDate = DateTime.Now;
                income.LastUpdatedBy = incomeVM.LastUpdatedBy;
                income.Note = incomeVM.Note;

                repository.Update(income);
                repository.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(incomeVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            IncomeVM incomeVM = new IncomeVM();
            Repository<Income> repository = new Repository<Income>();
            Income income = repository.GetById(id);
            incomeVM.Id = income.Id;
            incomeVM.AccountHeadId = income.AccountHeadId;
            incomeVM.Title = income.Title;
            incomeVM.LastUpdatedDate = income.LastUpdatedDate;
            incomeVM.Amount = income.Amount;
            incomeVM.Attachment = income.Attachment;
            incomeVM.LastUpdatedDate = DateTime.Now;
            incomeVM.LastUpdatedBy = income.LastUpdatedBy;
            incomeVM.Note = income.Note;
            return View(incomeVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Repository<Income> repository = new Repository<Income>();
            Income income = new Income();
            income = repository.GetById(id);
            repository.Delete(income.Id);  
            repository.Save();

            return RedirectToAction(nameof(Index));
        }

    }
}
