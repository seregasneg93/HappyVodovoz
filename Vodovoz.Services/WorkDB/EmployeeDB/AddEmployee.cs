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

namespace Vodovoz.Services.WorkDB.EmployeeDB
{
    public class AddEmployees : IEmployee
    {
        public async Task<string> AddNewEmployeeAsync(string name, string surName, string patronymis, DateTime dateBirth, string gender, string nameDevision)
        {
            Employee employee = new()
            {
                Name = name,
                SurName = surName,
                Patronymic = patronymis,
                DateBirth = dateBirth,
                Gender = gender,
            };

            using (DataContext db = new())
            {
                Devision devDb = await db.Devisions.FirstOrDefaultAsync(x => x.NameDevision.Equals(nameDevision));

                if (devDb != null)
                    employee.Devision = devDb;

                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
            }

            return "Работник добавлен в базу данных";
        }

        public async Task<string> ChangeEmployee(EmployeePresenter employeePresenter, string nameDevision)
        {
            using (DataContext db = new())
            {
                Employee employeeDb = await db.Employees.FirstOrDefaultAsync(x => x.Id == employeePresenter.Id);
                Devision devDb = await db.Devisions.FirstOrDefaultAsync(x => x.NameDevision.Equals(nameDevision));

                if (employeeDb is null)
                    return "Данный работник не найден в базе данных";

                employeeDb.Name = employeePresenter.Name;
                employeeDb.SurName = employeePresenter.SurName;
                employeeDb.Patronymic = employeePresenter.Patronymic;
                employeeDb.DateBirth = employeePresenter.DateBirth;
                employeeDb.Gender = employeePresenter.Gender;
                employeeDb.Devision = devDb;

                await db.SaveChangesAsync();
            }

            return "Работник успешно изменен";
        }

        public async Task<string> DeleteEmployeeAsync(int idEmployee)
        {
            using (DataContext db = new())
            {
                Employee employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == idEmployee);

                if (employee is null)
                    return "Данный работник не найден в базе данных";

                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }

            return "Работник успешно удален";
        }

        public async Task<List<EmployeePresenter>> ReceiveAllEmployeePresentersAsync()
        {
            List<EmployeePresenter> collectionPresenters = new();
            List<Employee> employeesCollections = new();

            using (DataContext db = new())
            {
                employeesCollections = await db.Employees
                                                .Include(x=>x.Devision)
                                                .ToListAsync();
            }

            foreach (var emp in employeesCollections)
                collectionPresenters.Add(new EmployeePresenter(emp));

            return collectionPresenters;
        }
    }
}
