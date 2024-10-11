using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Автотранспорт.Models
{
    public class DriverModel
    {
        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public int Experience { get; set; }
        public bool? B { get; set; }
        public bool? C { get; set; }
        public bool? D { get; set; }

        public DriverModel()
        {

        }

        public DriverModel(int id, string fio, int experience, bool? b, bool? c, bool? d)
        {
            Id = id;
            Fio = fio;
            Experience = experience;
            B = b;
            C = c;
            D = d;
        }

        //public override string ToString()
        //{
        //    return "Id: " + Id + " Имя: " + Name + " Login: " + Login + "Пароль: " + Password + Admin;
        //}
    }
}
