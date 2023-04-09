using AutoMapper;
using ActivityLog.Application.Features.Budget.Queries.Common;
using ActivityLog.Domain.Entities;
using ActivityLog.Application.Features.Budget.Commands.CreateBudget;
using ActivityLog.Application.Features.Budget.Commands.UpdateBudget;
using ActivityLog.Application.Features.BudgetExpense.Queries.Common;
using ActivityLog.Application.Features.BudgetExpense.Commands.CreateBudgetExpense;
using ActivityLog.Application.Features.BudgetExpense.Commands.UpdateBudgetExpense;
using ActivityLog.Application.Features.Transaction.Queries.Common;
using ActivityLog.Application.Features.Transaction.Commands.CreateTransaction;
using ActivityLog.Application.Features.Transaction.Commands.UpdateTransaction;

namespace ActivityLog.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Budget, BudgetVm>().ReverseMap();
			CreateMap<CreateBudgetCommand, Budget>().ReverseMap();
			CreateMap<UpdateBudgetCommand, Budget>().ReverseMap();

			CreateMap<BudgetExpense, BudgetExpenseVm>().ReverseMap();
			CreateMap<CreateBudgetExpenseCommand, BudgetExpense>().ReverseMap();
			CreateMap<UpdateBudgetExpenseCommand, BudgetExpense>().ReverseMap();

			CreateMap<Transaction, TransactionVm>().ReverseMap();
			CreateMap<CreateTransactionCommand, Transaction>().ReverseMap();
			CreateMap<UpdateTransactionCommand, Transaction>().ReverseMap();
		}
	}
}
