using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vododvoz.Data.Data.Entyties
{
    public class Order
    {
        public int Id { get; set; }
        public string NameOrder { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
