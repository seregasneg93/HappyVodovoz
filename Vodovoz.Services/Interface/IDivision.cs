using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;
using Vodovoz.Services.Presenters;

namespace Vodovoz.Services.Interface
{
    public interface IDivision
    {
        Task<string> AddNewDivisionAsync(Devision division);
        Task<List<DivisionPresenter>> ReceiveAllDivisionAsync();
        Task<string> DeleteDivisionAsync(string nameDivision);
        Task<string> ChangeDevisionAsync(DivisionPresenter divisionPresenter);
    }

}
