using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PockOData.Api.Domain.Entities.Base;
using PockOData.Api.Domain.Interfaces;
using PockOData.Api.Infra.Context;

namespace PockOData.Api.Infra.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private DbSet<T> _dbSet;
    private DataContext _context;

    public Repository(DataContext context)
    {
        _dbSet = context.Set<T>();
        _context = context;
    }

    public async Task Create(T model)
    {
        await _dbSet.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T model)
    {
        var result = await _dbSet.SingleOrDefaultAsync(x => x.Id.Equals(model.Id));
        if (result == null)
            throw new KeyNotFoundException();

        _context.Entry(result).CurrentValues.SetValues(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var result = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        if (result == null)
            throw new KeyNotFoundException();

        _dbSet.Remove(result);
        await _context.SaveChangesAsync();
    }
}