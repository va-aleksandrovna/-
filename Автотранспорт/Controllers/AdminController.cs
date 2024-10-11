using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Numerics;
using Автотранспорт.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Автотранспорт.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cars()
        {
            CarRepository carsRepository = new CarRepository();
            var car = carsRepository.GetAll();

            return View(car);
        }

        public IActionResult AddCars()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCars(CarModel car)
        {
            if (ModelState.IsValid)
            {
                if (car != null)
                {
                    if (car.Image == null)
                    {
                        car.Image = "test.jpg";
                    }
                    var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                    // Создание нового пользователя и сохранение его в базу данных
                    Car newcar = new Car
                    {
                        Name = car.Name,
                        PriceHour = car.PriceHour,
                        PriceKm = car.PriceKm,
                        NumberSeats = car.NumberSeats,
                        Length = car.Length,
                        Width = car.Width,
                        Capacity = car.Capacity,
                        Image = car.Image
                    };
                    // Сохранение нового пользователя в базе данных
                    context.Cars.Add(newcar); // добавление нового пользователя
                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("Cars", "Admin");
                }
            }
            return View(car);
        }

        public IActionResult EditCars(int id)
        {
            CarRepository carsRepository = new CarRepository();
            var car = carsRepository.GetById(id);

            return View(car);
        }

        [HttpPost]
        public IActionResult EditCars(CarModel car)
        {
            if (ModelState.IsValid)
            {
                if (car != null)
                {
                    var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                    CarRepository carsRepository = new CarRepository();
                    var newcar = context.Cars.FirstOrDefault(u => u.Id == car.Id);
                    newcar.Id = car.Id;
                    newcar.Name = car.Name;
                    newcar.PriceHour = car.PriceHour;
                    newcar.PriceKm = car.PriceKm;
                    newcar.NumberSeats = car.NumberSeats;
                    newcar.Length = car.Length;
                    newcar.Width = car.Width;
                    newcar.Capacity = car.Capacity;
                    newcar.Image = car.Image;

                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("Cars", "Admin");
                }
            }
            return View(car);
        }

        public IActionResult DeleteCars(int id)
        {
            if (ModelState.IsValid)
            {
                var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                var car = context.Cars.FirstOrDefault(u => u.Id == id);
                context.Cars.Remove(car);
                context.SaveChanges();

                return RedirectToAction("Cars", "Admin");
            }
            return View("Cars");
        }

        public IActionResult Drivers()
        {
            DriverRepository driverssRepository = new DriverRepository();
            var drivers = driverssRepository.GetAll();

            return View(drivers);
        }

        public IActionResult AddDrivers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDrivers(DriverModel driver)
        {
            if (ModelState.IsValid)
            {
                if (driver != null)
                {
                    var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                    // Создание нового пользователя и сохранение его в базу данных
                    Driver newdriver = new Driver
                    {
                        Fio = driver.Fio,
                        Experience = driver.Experience,
                        B = driver.B,
                        C = driver.C,
                        D = driver.D
                    };
                    // Сохранение нового пользователя в базе данных
                    context.Drivers.Add(newdriver); // добавление нового пользователя
                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("Drivers", "Admin");
                }
            }
            return View(driver);
        }

        public IActionResult EditDrivers(int id)
        {
            DriverRepository driverssRepository = new DriverRepository();
            var product = driverssRepository.GetById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditDrivers(DriverModel driver)
        {
            if (ModelState.IsValid)
            {
                if (driver != null)
                {
                    var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                    DriverRepository driverssRepository = new DriverRepository();
                    var newdriver = context.Drivers.FirstOrDefault(u => u.Id == driver.Id);
                    newdriver.Id = driver.Id;
                    newdriver.Fio = driver.Fio;
                    newdriver.Experience = driver.Experience;
                    newdriver.B = driver.B;
                    newdriver.C = driver.C;
                    newdriver.D = driver.D;

                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("Drivers", "Admin");
                }
            }
            return View(driver);
        }

        public IActionResult DeleteDrivers(int id)
        {
            if (ModelState.IsValid)
            {
                var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                var driver = context.Drivers.FirstOrDefault(u => u.Id == id);
                context.Drivers.Remove(driver);
                context.SaveChanges();

                return RedirectToAction("Drivers", "Admin");
            }
            return View("Drivers");
        }

        public IActionResult Work()
        {
            WorkRepository worksRepository = new WorkRepository();
            var works = worksRepository.GetAll();

            return View(works);
        }

        public IActionResult GetNew()
        {
            WorkRepository worksRepository = new WorkRepository();
            var works = worksRepository.GetList(null);

            return View("Work", works);
        }

        public IActionResult GetIn()
        {
            WorkRepository worksRepository = new WorkRepository();
            var works = worksRepository.GetList(false);

            return View("Work", works);
        }

        public IActionResult GetClose()
        {
            WorkRepository worksRepository = new WorkRepository();
            var works = worksRepository.GetList(true);

            return View("Work", works);
        }

        public IActionResult AddWork()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWork(WorkModel work)
        {
            if (ModelState.IsValid)
            {
                if (work != null)
                {
                    if (work.Phone == "+7 (___) ___-__-__")
                    {
                        work.Error = "Введите номер";
                        return View("AddWork", work);
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

                    return RedirectToAction("Work", "Admin");
                }
            }
            return View(work);
        }

        public IActionResult EditWork(int id)
        {
            WorkRepository worksRepository = new WorkRepository();
            var works = worksRepository.GetById(id);

            int n;
            if (works.NumberPassenger == null)
            {
                n = 0;
            }
            else if (works.NumberPassenger < 8)
            {
                n = 1;
            }
            else { n = (int)works.NumberPassenger; }

            int t = 0;
            if (works.TypeTransit == "Пассажирская")
            {
                t = 1;
            }

            CarRepository carsRepository = new CarRepository();
            ViewBag.Cars = carsRepository.Get(n,t);

            DriverRepository driverssRepository = new DriverRepository();
            ViewBag.Drivers = driverssRepository.Get(n, t);

            return View(works);
        }

        [HttpPost]
        public IActionResult EditWork(WorkModel work)
        {
            if (ModelState.IsValid)
            {
                if (work != null)
                {
                    var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                    WorkRepository worksRepository = new WorkRepository();
                    var newwork = context.Works.FirstOrDefault(u => u.Id == work.Id);
                    newwork.Id = work.Id;
                    newwork.Name = work.Name;
                    newwork.Surname = work.Surname;
                    newwork.Email = work.Email;
                    newwork.Phone = work.Phone;
                    newwork.Data = work.Data;
                    newwork.Time = work.Time;
                    newwork.AddressFrom = work.AddressFrom;
                    newwork.AddressTo = work.AddressTo;
                    newwork.TypeTransit = work.TypeTransit;
                    newwork.NumberPassenger = work.NumberPassenger;
                    newwork.Comment = work.Comment;
                    newwork.DriversId = work.DriversId;
                    newwork.CarsId = work.CarsId;
                    newwork.Status = work.Status;

                    context.SaveChanges(); // сохранение изменений в базе данных

                    return RedirectToAction("Work", "Admin");
                }
            }
            //return View(work);

            string errorMessages = "";
            // проходим по всем элементам в ModelState
            foreach (var item in ModelState)
            {
                // если для определенного элемента имеются ошибки
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = $"{errorMessages}\nОшибки для свойства {item.Key}:\n";
                    // пробегаемся по всем ошибкам
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                    }
                }
            }
            work.Error = errorMessages;
            return View("EditWork", work);
        }

        public IActionResult DeleteWork(int id)
        {
            if (ModelState.IsValid)
            {
                var context = new AlgazinaTrpoContext(); // создание экземпляра контекста
                var work = context.Works.FirstOrDefault(u => u.Id == id);
                context.Works.Remove(work);
                context.SaveChanges();

                return RedirectToAction("Work", "Admin");
            }
            return View("Work");
        }
    }
}
