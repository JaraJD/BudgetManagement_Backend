﻿using ActivityLog.Application.Contracts.Persistence;
using ActivityLog.Domain.Entities.Common;
using ActivityLog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ActivityLog.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
	{
		protected readonly ActivityLogDbContext _context;

		public RepositoryBase(ActivityLogDbContext context)
		{
			_context = context;
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}


		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T> CreateAsync(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public void AddEntity(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void UpdateEntity(T entity)
		{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public void DeleteEntity(T entity)
		{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

	}
}
