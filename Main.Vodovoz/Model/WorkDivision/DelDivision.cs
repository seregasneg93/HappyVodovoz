using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Interface;
using Vodovoz.Services.WorkDB.DivisionDb;

namespace Main.Vodovoz.Model.WorkDivision
{
    public class DelDivision
    {
        AddDivision _addDivision = new();

        public async Task<string> DeleteDevisionAsync(string nameDivision)
        {
            IDivision division = _addDivision;

            return await division.DeleteDivisionAsync(nameDivision);
        }
    }
}
