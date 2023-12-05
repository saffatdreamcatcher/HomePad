using ApplicationCore.Entities;
using HomePad.Models;
using Infrastructure.Data_Access;
using Microsoft.AspNetCore.Mvc;

namespace HomePad.Controllers
{
    public class AccountHeadController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountHeadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
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
            return View(accountHeadVMs);
        }

        public IActionResult Create()
        {
            AccountHeadVM accountHeadVM = new AccountHeadVM();
            return View(accountHeadVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] AccountHeadVM accountHeadVM)
        {
            if (ModelState.IsValid)
            {
                Repository<AccountHead> repository = new Repository<AccountHead>();
                
                AccountHead accountHead = new AccountHead();
                accountHead.Id = accountHeadVM.Id;
                accountHead.Name = accountHeadVM.Name;

                repository.Insert(accountHead);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(accountHeadVM);
        }


        public IActionResult Edit(int Id)
        {
            AccountHeadVM accountHeadVM = new AccountHeadVM();
            Repository<AccountHead> repository = new Repository<AccountHead>();
            AccountHead accountHead = repository.GetById(Id);
            accountHeadVM.Id = accountHead.Id;
            accountHeadVM.Name = accountHead.Name;
            return View(accountHeadVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AccountHeadVM accountHeadVM)
        {
            if (id != accountHeadVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                Repository<AccountHead> repository = new Repository<AccountHead>();
                AccountHead accountHead = new AccountHead();
                accountHead.Id = accountHeadVM.Id;
                accountHead.Name = accountHeadVM.Name;
                repository.Update(accountHead);
                repository.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(accountHeadVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            AccountHeadVM accountHeadVM = new AccountHeadVM();
            Repository<AccountHead> repository = new Repository<AccountHead>();
            AccountHead accountHead = new AccountHead();
            accountHead = repository.GetById(id);
            accountHeadVM.Id = accountHead.Id;
            accountHeadVM.Name = accountHead.Name;
            return View(accountHeadVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Repository<AccountHead> repository = new Repository<AccountHead>();
            AccountHead accountHead = new AccountHead();
            accountHead = repository.GetById(id);
            repository.Delete(accountHead.Id);
            repository.Save();

            return RedirectToAction(nameof(Index));
        }


    }
}
