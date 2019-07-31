namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items.Select(x => x.Name).ToList(),
                Employees = this.context.Employees.Select(x => x.Name).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);
            order.DateTime = DateTime.Now;

            var item = this.context
               .Items
               .FirstOrDefault(x => x.Name == model.ItemName);

            var employee = this.context
               .Employees
               .FirstOrDefault(x => x.Name == model.EmployeeName);

            if (item != null)
            {
                order.OrderItems.Add(new OrderItem()
                {
                    ItemId = item.Id,
                    Order = order,
                    Quantity = model.Quantity
                });
            }

            order.Type = Enum.Parse<OrderType>(model.OrderType);

            if (employee != null)
            {
                order.EmployeeId = employee.Id;
            }            

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context
               .Orders
               .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
               .ToList();

            return this.View(orders);
        }
    }
}
