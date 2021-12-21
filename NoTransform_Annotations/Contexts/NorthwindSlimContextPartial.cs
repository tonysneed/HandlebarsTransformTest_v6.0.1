//using System;
//using Microsoft.EntityFrameworkCore;
//using NoTransform_Annotations.Models;
//using dbo = NoTransform_Annotations.Models.dbo;

//namespace NoTransform_Annotations.Contexts
//{
//    public partial class NorthwindSlimContext
//    {
//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
//        {
//#pragma warning disable CS8604 // Possible null reference argument.
//            modelBuilder.Entity<dbo.Employee>()
//                .Property(e => e.Country)
//                .HasConversion(
//                    v => v.ToString(),
//                    v => (Country)Enum.Parse(typeof(Country?), v));

//            modelBuilder.Entity<dbo.Customer>()
//                .Property(e => e.Country)
//                .HasConversion(
//                    v => v.ToString(),
//                    v => (Country)Enum.Parse(typeof(Country?), v));
//#pragma warning restore CS8604 // Possible null reference argument.
//        }
//    }
//}