namespace Автотранспорт.Models
{
    public class WorkRepository
    {
        public List<WorkModel> GetAll()
        {
            List<WorkModel> works = new List<WorkModel>();
            using (AlgazinaTrpoContext bd = new AlgazinaTrpoContext())
            {
                works = bd.Works.Select(List => new WorkModel()
                {
                    Id = List.Id,
                    Name = List.Name,
                    Surname = List.Surname,
                    Email = List.Email,
                    Phone = List.Phone,
                    Data = List.Data,
                    Time = List.Time,
                    AddressFrom = List.AddressFrom,
                    AddressTo = List.AddressTo,
                    TypeTransit = List.TypeTransit,
                    NumberPassenger = List.NumberPassenger,
                    Comment = List.Comment,
                    DriversId = List.DriversId,
                    CarsId = List.CarsId,
                    Status = List.Status
                }).ToList();
            }
            return works;
        }

        public WorkModel GetById(int id)
        {
            List<WorkModel> works = GetAll();

            var work = works.Find(p => p.Id == id);
            return work;
        }

        public List<WorkModel> GetList(bool? status)
        {
            List<WorkModel> works = new List<WorkModel>();
            using (AlgazinaTrpoContext bd = new AlgazinaTrpoContext())
            {
                var worksQuery = bd.Works.Select(List => new WorkModel()
                {
                    Id = List.Id,
                    Name = List.Name,
                    Surname = List.Surname,
                    Email = List.Email,
                    Phone = List.Phone,
                    Data = List.Data,
                    Time = List.Time,
                    AddressFrom = List.AddressFrom,
                    AddressTo = List.AddressTo,
                    TypeTransit = List.TypeTransit,
                    NumberPassenger = List.NumberPassenger,
                    Comment = List.Comment,
                    DriversId = List.DriversId,
                    CarsId = List.CarsId,
                    Status = List.Status
                });

                switch (status)
                {
                    case null:
                        {
                            worksQuery = worksQuery.Where(p => p.Status == null);
                            break;
                        }
                    case false:
                        {
                            worksQuery = worksQuery.Where(p => p.Status == false);
                            break;
                        }
                    case true:
                        {
                            worksQuery = worksQuery.Where(p => p.Status == true);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                works = worksQuery.ToList();
            }

            return works;
        }
    }
}
