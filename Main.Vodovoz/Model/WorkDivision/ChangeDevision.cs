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
    public class ChangeDevision
    {
        AddDivision _addDivision = new();

        public async Task<string> ChangeDevisionAsync(DivisionPresenter devisionPresenter)
        {
            IDivision division = _addDivision;

            return await division.ChangeDevisionAsync(devisionPresenter);
        }
    }
}
