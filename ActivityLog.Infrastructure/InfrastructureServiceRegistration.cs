
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ActivityLog.Infrastructure.Persistence;
using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Infrastructure.Repositories;

namespace ActivityLog.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ActivityLogDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
			);

			services.AddScoped<IBudgetExpenseRepository, BudgetExpenseRepository>();
			services.AddScoped<IBudgetRepository, BudgetRepository>();
			services.AddScoped<ITransactionRepository, TransactionRepository>();

			return services;
		}
	}
}
