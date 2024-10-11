using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Автотранспорт.Models
{
    public class WorkModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Email { get; set; }
        public string Phone { get; set; } = null!;
        public DateTime Data { get; set; }
        public TimeSpan Time { get; set; }
        public string AddressFrom { get; set; } = null!;
        public string AddressTo { get; set; } = null!;
        public string TypeTransit { get; set; } = null!;
        public int? NumberPassenger { get; set; }
        public string? Comment { get; set; }
        public int? DriversId { get; set; }
        public int? CarsId { get; set; }
        public bool? Status { get; set; }
        public string? Error { get; set; }

        public WorkModel()
        {

        }

        public WorkModel(int id, string name, string surname, string? email, string phone, DateTime data,
            TimeSpan time, string addressFrom, string addressTo, string typeTransit,
            int? numberPassenger, string? comment, int? driversId, int carsId, bool? status, string error)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Data = data;
            Time = time;
            AddressFrom = addressFrom;
            AddressTo = addressTo;
            TypeTransit = typeTransit;
            NumberPassenger = numberPassenger;
            Comment = comment;
            DriversId = driversId;
            CarsId = carsId;
            Status = status;
            Error = error;
        }

        //public override string ToString()
        //{
        //    return "Id: " + Id + " Имя: " + Name + " Login: " + Login + "Пароль: " + Password + Admin;
        //}
    }
}
