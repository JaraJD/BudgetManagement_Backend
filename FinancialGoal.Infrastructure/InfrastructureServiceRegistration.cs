using FinancialGoal.Application.Contracts.Persistence;
using FinancialGoal.Infrastructure.Persistence;
using FinancialGoal.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoal.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TargetSavingDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
			);

			services.AddScoped<ITargetSavingRepository, TargetSavingRepository>();

			return services;
		}
	}
}
