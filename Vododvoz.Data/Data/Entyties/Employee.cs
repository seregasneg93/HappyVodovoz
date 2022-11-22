using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vododvoz.Data.Data.Entyties
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Devision Devision { get; set; }
    }
}
