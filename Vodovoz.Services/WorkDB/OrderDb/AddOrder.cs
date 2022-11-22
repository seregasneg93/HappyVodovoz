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

namespace Vodovoz.Services.WorkDB.OrderDb
{
    public class AddOrdeer : IOrder
    {
        public async Task<string> AddNewOrderInDbAsync(string nameOrder, List<EmployeePresenter> collectionEmployee)
        {
            Order order = new Order
            {
                NameOrder = nameOrder,
                Employees = new List<Employee>()
            };

            using (DataContext db = new())
            {
                List<Employee> employeeDb = await db.Employees.ToListAsync();

                foreach (var empPr in collectionEmployee)
                {
                    Employee validEmp = employeeDb.FirstOrDefault(x => x.Id == empPr.Id);

                    if (validEmp != null)
                        order.Employees.Add(validEmp);
                }

                await db.Orders.AddAsync(order);
                await db.SaveChangesAsync();
            }

            return "Заказ добавлен";
        }

        public async Task<string> CurrentOrderAsync(OrderPresenter selectedOrder)
        {
            Order orderDB = new();
            List<Employee> employees = new();

            using (DataContext db = new())
            {
                orderDB = await db.Orders
                                    .Include(x => x.Employees)
                                    .FirstOrDefaultAsync(x => x.Id == selectedOrder.Id);

                employees = await db.Employees.ToListAsync();


                if (orderDB is null)
                    return "Такой заказ не найден в базе данных";

                orderDB.NameOrder = selectedOrder.NameOrder;

                foreach (var empPresenter in selectedOrder.EmployeePresenters)
                {
                    var findPresenter = orderDB.Employees.FirstOrDefault(x => x.Id == empPresenter.Id);

                    if (findPresenter is null && empPresenter.IsOrder)
                    {
                        var findPresenterDb = employees.FirstOrDefault(x => x.Id == empPresenter.Id);

                        if (findPresenterDb != null)
                            orderDB.Employees.Add(findPresenterDb);
                    }
                    if (findPresenter != null && !empPresenter.IsOrder)
                    {
                        orderDB.Employees.Remove(findPresenter);
                    }
                }

                await db.SaveChangesAsync();
            }
            return "Данный заказ изменен";
        }

        public async Task<string> DeleteOrderAsync(int idOrder)
        {
            using (DataContext db = new())
            {
                Order orderDb = await db.Orders.FirstOrDefaultAsync(x => x.Id == idOrder);

                if (orderDb is null)
                    return "Данный заказ не был найден в базе данных";

                db.Remove(orderDb);
                await db.SaveChangesAsync();
            }

            return "Данный заказ удален";
        }

        public async Task<List<OrderPresenter>> ReceiveAllOredersPresentersSync()
        {
            List<OrderPresenter> ordersCollectionsPresenter = new();
            List<Order> oredersCollections = new();

            using (DataContext db = new())
            {
                oredersCollections = await db.Orders
                                              .Include(x => x.Employees)
                                                    .ThenInclude(x=>x.Devision)
                                              .ToListAsync();
            }

            foreach (var eroder in oredersCollections)
                ordersCollectionsPresenter.Add(new OrderPresenter(eroder, eroder.Employees.ToList()));

            return ordersCollectionsPresenter;
        }

        public async Task<List<EmployeePresenter>> ReceiveValidEmploueePresenterAsync(OrderPresenter selectedOrder)
        {
            List<Employee> employeeDb = new();
            List<EmployeePresenter> emplPresenters = new();

            using (DataContext db = new())
            {
                employeeDb = await db.Employees
                                        .Include(x=>x.Orders)
                                        .Include(x=>x.Devision)
                                        .ToListAsync();
            }

            foreach (var emp in employeeDb)
                emplPresenters.Add(new EmployeePresenter(emp));

            foreach (var emp in emplPresenters)
            {
                foreach (var order in emp.OrderPresenters)
                {
                    if (order.Id == selectedOrder.Id)
                        emp.IsOrder = true;
                }
            }

            return emplPresenters;
        }
    }
}
