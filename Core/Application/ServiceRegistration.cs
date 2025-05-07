using Application.Validators.ExpenseCategories;
using Application.Validators.Expenses;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddControllers().AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<CreateExpenseCommandValidator>();
            });

            collection.AddMediatR(typeof(ServiceRegistration));

            collection.AddAutoMapper(Assembly.GetExecutingAssembly());

            collection.AddHttpContextAccessor();

        }
    }
}
