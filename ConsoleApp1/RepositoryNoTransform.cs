using Microsoft.EntityFrameworkCore;
using NoTransformAnnotations = NoTransform_Annotations.Contexts;
using NoTransformFluent = NoTransform_Fluent.Contexts;

namespace ConsoleApp1
{
    public static class RepositoryNoTransform
    {
        public static void ProcessFluent()
        {
            using (var context = new NoTransformFluent.NorthwindSlimContext())
            {
                Console.WriteLine("Categories:");
                foreach (var category in context.Categories
                             .Include(e => e.Products))
                {
                    Console.WriteLine("{0} {1}", category.CategoryId, category.CategoryName);
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine("\t{0} {1}", product.ProductId, product.ProductName);
                    }
                }

                Console.WriteLine("\nCustomers:");
                foreach (var customer in context.Customers
                             .Include(e => e.CustomerSetting)
                             .Include(e => e.Orders)
                             .ThenInclude(e => e.OrderDetails)
                             .ThenInclude(e => e.Product))
                {
                    Console.WriteLine("{0} {1} {2}", customer.CustomerId, customer.CompanyName, customer.CustomerSetting?.Setting);
                    if (customer.Orders.Any())
                    {
                        Console.WriteLine("\tOrders:");
                        foreach (var order in customer.Orders)
                        {
                            Console.WriteLine("\t{0} {1}", order.OrderId, order.OrderDate?.ToShortDateString());
                            foreach (var detail in order.OrderDetails)
                            {
                                Console.WriteLine("\t\t{0} {1}", detail.Product.ProductName, detail.Quantity);
                            }
                        }
                    }
                }

                Console.WriteLine("\nEmployees:");
                foreach (var employee in context.Employees
                             .Include(e => e.Territories))
                {
                    Console.WriteLine("{0} {1} {2}", employee.EmployeeId, employee.FirstName, employee.LastName);
                    if (employee.Territories.Any())
                    {
                        Console.WriteLine("\tTerritories:");
                        foreach (var territory in employee.Territories)
                        {
                            Console.WriteLine("\t{0} {1}", territory.TerritoryId, territory.TerritoryDescription);
                        }
                    }
                }
            }
        }

        public static void ProcessAnnotations()
        {
            using (var context = new NoTransformAnnotations.NorthwindSlimContext())
            {
                Console.WriteLine("Categories:");
                foreach (var category in context.Categories
                             .Include(e => e.Products))
                {
                    Console.WriteLine("{0} {1}", category.CategoryId, category.CategoryName);
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine("\t{0} {1}", product.ProductId, product.ProductName);
                    }
                }

                Console.WriteLine("\nCustomers:");
                foreach (var customer in context.Customers
                             .Include(e => e.CustomerSetting)
                             .Include(e => e.Orders)
                             .ThenInclude(e => e.OrderDetails)
                             .ThenInclude(e => e.Product))
                {
                    Console.WriteLine("{0} {1} {2}", customer.CustomerId, customer.CompanyName, customer.CustomerSetting?.Setting);
                    if (customer.Orders.Any())
                    {
                        Console.WriteLine("\tOrders:");
                        foreach (var order in customer.Orders)
                        {
                            Console.WriteLine("\t{0} {1}", order.OrderId, order.OrderDate?.ToShortDateString());
                            foreach (var detail in order.OrderDetails)
                            {
                                Console.WriteLine("\t\t{0} {1}", detail.Product.ProductName, detail.Quantity);
                            }
                        }
                    }
                }

                Console.WriteLine("\nEmployees:");
                foreach (var employee in context.Employees
                             .Include(e => e.Territories))
                {
                    Console.WriteLine("{0} {1} {2}", employee.EmployeeId, employee.FirstName, employee.LastName);
                    if (employee.Territories.Any())
                    {
                        Console.WriteLine("\tTerritories:");
                        foreach (var territory in employee.Territories)
                        {
                            Console.WriteLine("\t{0} {1}", territory.TerritoryId, territory.TerritoryDescription);
                        }
                    }
                }
            }
        }
    }
}
