using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using Автотранспорт.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Автотранспорт.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Index(WorkModel work)
        {
            if (ModelState.IsValid)
            {
                if (work != null)
                {
                    if (work.Phone == "+7 (___) ___-__-__")
                    {
                        work.Error = "Введите номер";
                        return View("Index", work);
                    }
                    var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                    // Создание нового пользователя и сохранение его в базу данных
                    Work newwork = new Work
                    {
                        Name = work.Name,
                        Surname = work.Surname,
                        Email = work.Email,
                        Phone = work.Phone,
                        Data = work.Data,
                        Time = work.Time,
                        AddressFrom = work.AddressFrom,
                        AddressTo = work.AddressTo,
                        TypeTransit = work.TypeTransit,
                        NumberPassenger = work.NumberPassenger,
                        Comment = work.Comment,
                        DriversId = work.DriversId,
                        CarsId = work.CarsId,
                        Status = work.Status
                    };
                    // Сохранение нового пользователя в базе данных
                    context.Works.Add(newwork); // добавление нового пользователя
                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("Index2", "Home");
                }
            }
            return View(work);
        }

        public IActionResult Index2()
        {
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