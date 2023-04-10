using AutoMapper;
using UserAuthentication.DrivenAdapter.EntitiesMongo;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;

namespace UserAuthentication.AppService.Mapping
{
	public class ConfigurationProfile : Profile
	{
		public ConfigurationProfile()
		{
			CreateMap<BalanceEntity, BalanceMongo>().ReverseMap();
			CreateMap<CreateBalanceCommand, BalanceMongo>().ReverseMap();
		}
	}
}
