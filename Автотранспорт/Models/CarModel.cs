using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Автотранспорт.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double PriceHour { get; set; }
        public double PriceKm { get; set; }
        public int? NumberSeats { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Capacity { get; set; }
        public string? Image { get; set; }

        public CarModel()
        {

        }

        public CarModel(int id, string name, double priceHour, double priceKm, int? numberSeats, double? length, double? width,
            double? capacity, string? image)
        {
            Id = id;
            Name = name;
            PriceHour = priceHour;
            PriceKm = priceKm;
            NumberSeats = numberSeats;
            Length = length;
            Width = width;
            Capacity = capacity;
            Image = image;
        }

        //public override string ToString()
        //{
        //    return "Id: " + Id + " Имя: " + Name + " Login: " + Login + "Пароль: " + Password + Admin;
        //}
    }
}
