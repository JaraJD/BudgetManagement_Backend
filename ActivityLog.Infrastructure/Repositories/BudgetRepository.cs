﻿using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities;
using ActivityLog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ActivityLog.Infrastructure.Repositories
{
	public class BudgetRepository : RepositoryBase<Budget>, IBudgetRepository
	{
		static HttpClient client = new HttpClient();
		public BudgetRepository(ActivityLogDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<Budget>> GetBudgetByDate(string user, DateTime date)
		{
			return await _context.Budget!.Where(t => t.IdUser == user &&
												t.TargetMonth.Month == date.Month &&
												t.TargetMonth.Year == date.Year &&
												t.IsDeleted == false).Include(r => r.BudgetExpense).ThenInclude(c => c.Category).ToListAsync();
		}

		public async Task<IEnumerable<Budget>> GetBudgetByName(string user, string name)
		{
			return await _context.Budget!.Where(t => t.IdUser == user && t.Name == name && t.IsDeleted == false).Include(r => r.BudgetExpense).ThenInclude(c => c.Category).ToListAsync();
		}

		public async Task<IEnumerable<Budget>> GetBudgetByState(string user, string state)
		{
			return await _context.Budget!.Where(t => t.IdUser == user && t.State == state && t.IsDeleted == false).Include(r => r.BudgetExpense).ThenInclude(c => c.Category).ToListAsync();
		}

		public async Task<IEnumerable<Budget>> GetBudgetByUser(string user)
		{
			return await _context.Budget!.Where(t => t.IdUser == user && t.IsDeleted == false).Include(r => r.BudgetExpense).ThenInclude(c => c.Category).ToListAsync();
		}

		public async Task<string> SetMonthlyTotalBudget(Budget budget)
		{
			_context.Set<Budget>().Attach(budget);
			_context.Entry(budget).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return "Updated";
		}
	}
}
