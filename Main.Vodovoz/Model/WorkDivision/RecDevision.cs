using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Interface;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.WorkDB.DivisionDb;

namespace Main.Vodovoz.Model.WorkDivision
{
    public class RecDevision
    {
        AddDivision _addDivision = new();

        public async Task<List<string>> ReceiveDivisionsPresenterAsync()
        {
            IDivision division = _addDivision;

            List<DivisionPresenter> divisionPresenters = await division.ReceiveAllDivisionAsync().ConfigureAwait(false);

            return divisionPresenters.Select(x => x.NameDevision).ToList();
        }

        public async Task<List<DivisionPresenter>> ReceiveDivisionsPresenterAsync(int index)
        {
            IDivision division = _addDivision;

            List<DivisionPresenter> divisionPresenters = await division.ReceiveAllDivisionAsync().ConfigureAwait(false);

            return divisionPresenters;
        }
    }
}
