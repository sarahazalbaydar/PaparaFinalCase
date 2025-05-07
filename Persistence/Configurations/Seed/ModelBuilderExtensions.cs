using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            DateTime now = DateTime.Now;
            modelBuilder.Entity<ExpenseCategory>().HasData(
                new ExpenseCategory { Id = 1, Title = "Meal", Description = "Meals and food expenses during field work", CreatedDate = now },
                new ExpenseCategory { Id = 2, Title = "Transportation", Description = "Travel expenses including fuel, public transport, or company car usage", CreatedDate = now },
                new ExpenseCategory { Id = 3, Title = "Accommodation", Description = "Hotel or lodging costs during business trips", CreatedDate = now },
                new ExpenseCategory { Id = 4, Title = "Office Supplies", Description = "Stationery and basic tools used during field tasks", CreatedDate = now },
                new ExpenseCategory { Id = 5, Title = "Mobile / Internet", Description = "Mobile data or communication-related expenses for work", CreatedDate = now },
                new ExpenseCategory { Id = 6, Title = "Customer Meeting", Description = "Costs incurred during customer visits or meetings", CreatedDate = now },
                new ExpenseCategory { Id = 7, Title = "Field Equipment", Description = "Small equipment or protective gear used on-site", CreatedDate = now },
                new ExpenseCategory { Id = 8, Title = "Other", Description = "Miscellaneous expenses not covered by other categories", CreatedDate = now }
    );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    UserName = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin12345"), // hash of "12345678"
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    PhoneNumber = "5341234567",
                    IBAN = "TR120006200000000123456789",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    UserName = "employee",
                    Password = BCrypt.Net.BCrypt.HashPassword("Emp1234567"), // hash of "1234asdf"
                    FirstName = "Employee",
                    LastName = "User",
                    Email = "employee@example.com",
                    PhoneNumber = "5309876543",
                    IBAN = "TR650006200000000987654321",
                    Role = UserRole.Employee
                }
            );

        }
    }
}
