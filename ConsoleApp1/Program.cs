// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Microsoft.EntityFrameworkCore;
using ScaffoldingSample1.Contexts;

using (var context = new NorthwindSlimContext())
{
    Console.WriteLine("Categories:");
    foreach (var category in context.Categories)
    {
        Console.WriteLine("{0} {1}", category.CategoryIdFoo, category.CategoryNameFoo);
    }

    Console.WriteLine("\nCustomers:");
    foreach (var customer in context.Customers
        .Include(e => e.OrdersFoo)
        .ThenInclude(e => e.OrderDetailsFoo)
        .ThenInclude(e => e.ProductFoo))
    {
        Console.WriteLine("{0} {1}", customer.CustomerIdFoo, customer.CompanyNameFoo);
        if (customer.OrdersFoo.Any())
        {
            Console.WriteLine("\tOrders:");
            foreach (var order in customer.OrdersFoo)
            {
                Console.WriteLine("\t{0} {1}", order.OrderIdFoo, order.OrderDateFoo?.ToShortDateString());
                foreach (var detail in order.OrderDetailsFoo)
                {
                    Console.WriteLine("\t\t{0} {1}", detail.ProductFoo.ProductNameFoo, detail.QuantityFoo);
                }
            } 
        }
    }

    Console.WriteLine("\nEmployees:");
    foreach (var employee in context.Employees
        .Include(e => e.TerritoriesFoo))
    {
        Console.WriteLine("{0} {1} {2}", employee.EmployeeIdFoo, employee.FirstNameFoo, employee.LastNameFoo);
        if (employee.TerritoriesFoo.Any())
        {
            Console.WriteLine("\tTerritories:");
            foreach (var territory in employee.TerritoriesFoo)
            {
                Console.WriteLine("\t{0} {1}", territory.TerritoryIdFoo, territory.TerritoryDescriptionFoo);
            }
        }
    }
}