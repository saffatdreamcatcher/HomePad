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
    }
}
