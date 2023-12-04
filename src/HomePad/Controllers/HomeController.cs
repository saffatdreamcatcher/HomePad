using ApplicationCore.Entities;
using HomePad.Models;
using Infrastructure.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace HomePad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Repository<AccountHead>  repository = new Repository<AccountHead>();
            //AccountHead accountHead = new AccountHead();
            ////accountHead.Id = 1;
            //accountHead.Name = "Test55";
            ////accountHead.Name = "Test222";
            ////accountHead.Name = "Test00";
            ////repository.Insert(accountHead);
            ////IEnumerable<AccountHead> aH = repository.GetAll();
            //AccountHead head = repository.GetById(2);
            ////repository.Delete(head.Id);
            //head.Name = "Test50";

            //repository.Update(head);
            //repository.Save();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}