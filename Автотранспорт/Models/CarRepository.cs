using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace Автотранспорт.Models
{
    public class CarRepository
    {
        public List<CarModel> GetAll()
        {
            List<CarModel> cars = new List<CarModel>();
            using (AlgazinaTrpoContext bd = new AlgazinaTrpoContext())
            {
                cars = bd.Cars.Select(List => new CarModel()
                {
                    Id = List.Id,
                    Name = List.Name,
                    PriceHour = List.PriceHour,
                    PriceKm = List.PriceKm,
                    NumberSeats = List.NumberSeats,
                    Length = List.Length,
                    Width = List.Width,
                    Capacity = List.Capacity,
                    Image = List.Image
                }).ToList();
            }
            return cars;
        }

        public CarModel GetById(int id)
        {
            List<CarModel> cars = GetAll();

            var car = cars.Find(p => p.Id == id);
            return car;
        }

        public List<CarModel> Get(int n, int t)
        {
            List<CarModel> cars = new List<CarModel>();
            using (AlgazinaTrpoContext bd = new AlgazinaTrpoContext())
            {
                var carsQuery = bd.Cars.Select(List => new CarModel()
                {
                    Id = List.Id,
                    Name = List.Name,
                    PriceHour = List.PriceHour,
                    PriceKm = List.PriceKm,
                    NumberSeats = List.NumberSeats,
                    Length = List.Length,
                    Width = List.Width,
                    Capacity = List.Capacity,
                    Image = List.Image
                });

                switch (t)
                {
                    case 0:
                        {
                            carsQuery = carsQuery.Where(p => p.Length != null);
                            break;
                        }
                    case 1:
                        {
                            if (n == 1)
                            {
                                carsQuery = carsQuery.Where(p => p.NumberSeats < 8);
                            }
                            else if (n == 0)
                            {
                                carsQuery = carsQuery.Where(p => p.NumberSeats != null);
                            }
                            else
                            {
                                carsQuery = carsQuery.Where(p => p.NumberSeats > n);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                cars = carsQuery.ToList();
            }

            return cars;
        }
    }
}
