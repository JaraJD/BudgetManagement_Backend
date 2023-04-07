using AutoMapper;
using FinancialGoal.Application.Features.TargetSaving.Commands.CreateTargetSaving;
using FinancialGoal.Application.Features.TargetSaving.Commands.DeleteTargetSaving;
using FinancialGoal.Application.Features.TargetSaving.Commands.UpdateTargetSaving;
using FinancialGoal.Application.Features.TargetSaving.Queries.Common;
using FinancialGoal.Domain.Entitie;

namespace FinancialGoal.Application.Mappings
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<TargetSaving, TargetSavingVm>().ReverseMap();
			CreateMap<CreateTargetSavingCommand, TargetSaving>().ReverseMap();
			CreateMap<UpdateTargetSavingCommand, TargetSaving>().ReverseMap();
			CreateMap<DeleteTargetSavingCommand, TargetSaving>().ReverseMap();
		}
	}
}
