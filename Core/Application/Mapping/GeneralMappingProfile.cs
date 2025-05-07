using Application.DTOs;
using Application.Features.Expense.Commands.CreateExpense;
using Application.Features.Expense.Commands.DeleteExpense;
using Application.Features.Expense.Commands.UpdateExpense;
using Application.Features.Expense.Queries.GetAllExpenses;
using Application.Features.Expense.Queries.GetExpenseById;
using Application.Features.ExpenseCategory.Commands.CreateExpenseCategory;
using Application.Features.ExpenseCategory.Commands.DeleteExpenseCategory;
using Application.Features.ExpenseCategory.Commands.UpdateExpenseCategory;
using Application.Features.ExpenseCategory.Queries.GetAllExpenseCategories;
using Application.Features.ExpenseCategory.Queries.GetExpenseCategoryById;
using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Commands.DeleteUser;
using Application.Features.User.Commands.UpdateUser;
using Application.Features.User.Queries.GetAllUsers;
using Application.Features.User.Queries.GetUserById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {

            CreateMap<GetAllExpenseCategoriesQueryRequest, ExpenseCategory>();
            CreateMap<ExpenseCategory, GetAllExpenseCategoriesQueryResponse>();

            CreateMap<GetExpenseCategoryByIdQueryRequest, ExpenseCategory>();
            CreateMap<ExpenseCategory, GetExpenseCategoryByIdQueryResponse>();

            CreateMap<CreateExpenseCategoryCommandRequest, ExpenseCategory>();
            CreateMap<ExpenseCategory, CreateExpenseCategoryCommandResponse>();

            CreateMap<UpdateExpenseCategoryCommandRequest, ExpenseCategory>();
            CreateMap<ExpenseCategory, UpdateExpenseCategoryCommandResponse>();

            CreateMap<DeleteExpenseCategoryCommandRequest, ExpenseCategory>();
            CreateMap<ExpenseCategory, DeleteExpenseCategoryCommandResponse>();

            CreateMap<CreateExpenseCommandRequest, CreateExpenseDto>();
            CreateMap<CreateExpenseDto, Expense>();
            CreateMap<Expense, CreateExpenseCommandResponse>();

            CreateMap<DeleteExpenseCommandRequest, Expense>();
            CreateMap<Expense, DeleteExpenseCommandResponse>();

            CreateMap<UpdateExpenseCommandRequest, UpdateExpenseDto>();
            CreateMap<UpdateExpenseDto, Expense>();
            CreateMap<Expense, UpdateExpenseCommandResponse>();

            CreateMap<GetAllExpensesQueryRequest, Expense>();
            CreateMap<Expense, GetAllExpensesQueryResponse>();
            
            CreateMap<GetExpenseByIdQueryRequest, Expense>();
            CreateMap<Expense, GetExpenseByIdQueryResponse>();

            CreateMap<CreateUserCommandRequest, RegisterDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<User, CreateUserCommandResponse>();

            CreateMap<DeleteUserCommandRequest, User>();
            CreateMap<User, DeleteUserCommandResponse>();

            CreateMap<GetAllUsersQueryRequest, User>();
            CreateMap<User, GetAllUsersQueryResponse>();

            CreateMap<GetUserByIdQueryRequest, User>();
            CreateMap<User, GetUserByIdQueryResponse>();

            CreateMap<ChangePasswordCommandRequest, User>();
        }
    }
}
