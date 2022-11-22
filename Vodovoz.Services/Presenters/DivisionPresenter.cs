using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;

namespace Vodovoz.Services.Presenters
{
    public class DivisionPresenter
    {
        public DivisionPresenter(Devision devision)
        {
            Id = devision.Id;
            NameDevision = devision.NameDevision;
        }

        public DivisionPresenter(DivisionPresenter divisionPresenter)
        {
            Id = divisionPresenter.Id;
            NameDevision = divisionPresenter.NameDevision;
        }

        public DivisionPresenter()
        {

        }

        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string NameDevision { get; set; }
    }
}
