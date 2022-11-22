using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;
using Vodovoz.Services.Interface;
using Vodovoz.Services.WorkDB.DivisionDb;

namespace Main.Vodovoz.Model.WorkDivision
{
    public class AddNewDivision 
    {
        AddDivision _addDivision = new();
        public async Task<string> AddNewDivFromDbAsync(string nameDivision)
        {
            Devision newDev = new();
            IDivision division = _addDivision;

            newDev.NameDevision = nameDivision; 

            return await division.AddNewDivisionAsync(newDev).ConfigureAwait(false);
        }
    }
}
