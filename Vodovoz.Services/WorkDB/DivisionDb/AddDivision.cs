using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.ConnectDB;
using Vododvoz.Data.Data.Entyties;
using Vodovoz.Services.Interface;
using Vodovoz.Services.Presenters;

namespace Vodovoz.Services.WorkDB.DivisionDb
{
    public class AddDivision : IDivision
    {
        public async Task<string> AddNewDivisionAsync(Devision nameDivision)
        {
            if (nameDivision is null)
                return "Не удалось добавить подразделение";

                using (DataContext db = new())
                {
                    await db.Devisions.AddAsync(nameDivision).ConfigureAwait(false);
                    await db.SaveChangesAsync().ConfigureAwait(false);
                }

            return "Подразделение добавлено";
        }

        public async Task<List<DivisionPresenter>> ReceiveAllDivisionAsync()
        {
            List<DivisionPresenter> divisionPresenters = new List<DivisionPresenter>();
            List<Devision> DevisionWithDb = new();
            using (DataContext db = new())
            {
                DevisionWithDb = await db.Devisions.ToListAsync().ConfigureAwait(false);
            }

                foreach (var devision in DevisionWithDb)
                    divisionPresenters.Add(new DivisionPresenter(devision));

            return divisionPresenters;
        }

        public async Task<string> DeleteDivisionAsync(string nameDivision)
        {
            using (DataContext db = new())
            {
                Devision devision = await db.Devisions.FirstOrDefaultAsync(x => x.NameDevision.Equals(nameDivision));

                if (devision is null)
                    return "Данное подразделение не найдено в базе данных";

                db.Devisions.Remove(devision);
                await db.SaveChangesAsync();
            }

            return "Подразделение успешно удалено";
        }

        public async Task<string> ChangeDevisionAsync(DivisionPresenter divisionPresenter)
        {
            using (DataContext db = new())
            {
                Devision devisionDb = await db.Devisions.FirstOrDefaultAsync(x => x.Id == divisionPresenter.Id);

                if(devisionDb is null)
                    return "Данное подразделение не найдено в базе данных";

                devisionDb.NameDevision = divisionPresenter.NameDevision;

                await db.SaveChangesAsync();
            }

            return "Подразделение успешно изменено";
        }
    }
}
