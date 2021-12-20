﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CardManagement.Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CardManagement.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _ctx;
        private readonly DbSet<T> _entitySet;

        protected BaseRepository(AppDbContext ctx)
        {
            _ctx = ctx;
            _entitySet = ctx.Set<T>();
        }
        public async Task Delete(int? id)
        {
            if (await Exist(id))
            {
                var entity = await Find(id);
                _ctx.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
        public async Task<bool> Exist(int? id)
        {
            var entity = await _entitySet.FindAsync(id);
            return entity != null;
        }
        public virtual async Task<T> Find(int? id)
        {
            var entity = await _entitySet.FindAsync(id);
            return entity;
        }
        public async Task<IEnumerable<T>> FindAll()
        {
            return await _entitySet.ToListAsync();
        }
        public async Task<int> Count()
        {
            return await _entitySet.CountAsync();
        }
        public virtual async Task Save(T t)
        {
            if (t != null)
            {
                await _entitySet.AddAsync(t);
                await _ctx.SaveChangesAsync();
            }
        }
        public async Task Update(T t)
        {
            if (t != null)
            {
                _ctx.Update(t);
                await _ctx.SaveChangesAsync();
            }
        }
        public async Task AddRange(IEnumerable<T> t)
        {
            await _ctx.AddRangeAsync(t);
            await _ctx.SaveChangesAsync();
        }
    }
}