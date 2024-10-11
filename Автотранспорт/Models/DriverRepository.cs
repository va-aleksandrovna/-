using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Автотранспорт.Models
{
    public class DriverRepository
    {
        public List<DriverModel> GetAll()
        {
            List<DriverModel> driver = new List<DriverModel>();
            using (AlgazinaTrpoContext bd = new AlgazinaTrpoContext())
            {
                driver = bd.Drivers.Select(List => new DriverModel()
                {
                    Id = List.Id,
                    Fio = List.Fio,
                    Experience = List.Experience,
                    B = List.B,
                    C = List.C,
                    D = List.D
                }).ToList();
            }
            return driver;
        }

        public DriverModel GetById(int id)
        {
            List<DriverModel> drivers = GetAll();

            var driver = drivers.Find(p => p.Id == id);
            return driver;
        }

        public List<DriverModel> Get(int n, int t)
        {
            List<DriverModel> drivers = new List<DriverModel>();
            using (AlgazinaTrpoContext bd = new AlgazinaTrpoContext())
            {
                var driversQuery = bd.Drivers.Select(List => new DriverModel()
                {
                    Id = List.Id,
                    Fio = List.Fio,
                    Experience = List.Experience,
                    B = List.B,
                    C = List.C,
                    D = List.D
                });

                switch (t)
                {
                    case 0:
                        {
                            driversQuery = driversQuery.Where(p => p.C == true);
                            break;
                        }
                    case 1:
                        {
                            if (n == 1)
                            {
                                driversQuery = driversQuery.Where(p => p.B == true);
                            }
                            else if (n == 0)
                            {
                                driversQuery = driversQuery.Where(p => p.D == true || p.B == true);
                            }
                            else
                            {
                                driversQuery = driversQuery.Where(p => p.D == true);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                drivers = driversQuery.ToList();
            }

            return drivers;
        }
    }
}
