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
    }
}
