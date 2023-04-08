using AutoMapper;
using ActivityLog.Application.Features.Budget.Queries.Common;
using ActivityLog.Domain.Entities;
using ActivityLog.Application.Features.Budget.Commands.CreateBudget;
using ActivityLog.Application.Features.Budget.Commands.UpdateBudget;

namespace ActivityLog.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Budget, BudgetVm>().ReverseMap();
			CreateMap<CreateBudgetCommand, Budget>().ReverseMap();
			CreateMap<UpdateBudgetCommand, Budget>().ReverseMap();
		}
	}
}
