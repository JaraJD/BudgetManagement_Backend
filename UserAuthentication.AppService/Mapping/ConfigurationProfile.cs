using AutoMapper;
using UserAuthentication.DrivenAdapter.EntitiesMongo;
using UserAuthentication.Entities.Entities;
using UserAuthentication.Entities.Features.Balance.Commands;
using UserAuthentication.Entities.Features.User.Commands;

namespace UserAuthentication.AppService.Mapping
{
	public class ConfigurationProfile : Profile
	{
		public ConfigurationProfile()
		{
			CreateMap<BalanceEntity, BalanceMongo>().ReverseMap();
			CreateMap<CreateBalanceCommand, BalanceMongo>().ReverseMap();

			CreateMap<UserMongo, UserEntity>().ReverseMap();
			CreateMap<CreateUserCommand, UserMongo>().ReverseMap();


		}
	}
}
