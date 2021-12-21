//using System;
//using Microsoft.EntityFrameworkCore;
//using Transform_Annotations.Models;
//using dbo = Transform_Annotations.Models.dbo;

//namespace Transform_Annotations.Contexts
//{
//    public partial class NorthwindSlimContext
//    {
//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
//        {
//#pragma warning disable CS8604 // Possible null reference argument.
//            modelBuilder.Entity<dbo.EmployeeFoo>()
//                .Property(e => e.CountryFoo)
//                .HasConversion(
//                    v => v.ToString(),
//                    v => (Country)Enum.Parse(typeof(Country?), v));

//            modelBuilder.Entity<dbo.CustomerFoo>()
//                .Property(e => e.CountryFoo)
//                .HasConversion(
//                    v => v.ToString(),
//                    v => (Country)Enum.Parse(typeof(Country?), v));
//#pragma warning restore CS8604 // Possible null reference argument.
//        }
//    }
//}