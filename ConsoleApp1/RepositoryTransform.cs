using Microsoft.EntityFrameworkCore;
using TransformAnnotations = Transform_Annotations.Contexts;
using TransformFluent = Transform_Fluent.Contexts;

namespace ConsoleApp1
{
    public static class RepositoryTransform
    {
        public static void ProcessFluent()
        {
            using (var context = new TransformFluent.NorthwindSlimContext())
            {
                Console.WriteLine("Categories:");
                foreach (var category in context.Categories
                             .Include(e => e.ProductsFoo))
                {
                    Console.WriteLine("{0} {1}", category.CategoryIdFoo, category.CategoryNameFoo);
                    foreach (var product in category.ProductsFoo)
                    {
                        Console.WriteLine("\t{0} {1}", product.ProductIdFoo, product.ProductNameFoo);
                    }
                }

                Console.WriteLine("\nCustomers:");
                foreach (var customer in context.Customers
                             .Include(e => e.CustomerSettingFoo)
                             .Include(e => e.OrdersFoo)
                             .ThenInclude(e => e.OrderDetailsFoo)
                             .ThenInclude(e => e.ProductFoo))
                {
                    Console.WriteLine("{0} {1} {2}", customer.CustomerIdFoo, customer.CompanyNameFoo, customer.CustomerSettingFoo?.SettingFoo);
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
        }

        public static void ProcessAnnotations()
        {
            using (var context = new TransformAnnotations.NorthwindSlimContext())
            {
                Console.WriteLine("Categories:");
                foreach (var category in context.Categories
                             .Include(e => e.ProductsFoo))
                {
                    Console.WriteLine("{0} {1}", category.CategoryIdFoo, category.CategoryNameFoo);
                    foreach (var product in category.ProductsFoo)
                    {
                        Console.WriteLine("\t{0} {1}", product.ProductIdFoo, product.ProductNameFoo);
                    }
                }

                Console.WriteLine("\nCustomers:");
                foreach (var customer in context.Customers
                             .Include(e => e.CustomerSettingFoo)
                             .Include(e => e.OrdersFoo)
                             .ThenInclude(e => e.OrderDetailsFoo)
                             .ThenInclude(e => e.ProductFoo))
                {
                    Console.WriteLine("{0} {1} {2}", customer.CustomerIdFoo, customer.CompanyNameFoo, customer.CustomerSettingFoo?.SettingFoo);
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
        }
    }
}
