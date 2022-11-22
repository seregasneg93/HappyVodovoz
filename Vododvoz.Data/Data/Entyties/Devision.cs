using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vododvoz.Data.Data.Entyties
{
    public class Devision
    {
        public int Id { get; set; }
        public string NameDevision { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
