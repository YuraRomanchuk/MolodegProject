﻿using Microsoft.EntityFrameworkCore;
using MolodegBackend.Domain.Repositories;
using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Repositories
{
    public class PlacardRepository : BaseRepository, IPlacardRepository
    {
        public PlacardRepository(AppDbContext context) : base(context)
        { }

        public async Task AddPlacardAsync(Placard placard)
        {
            await context.Placards.AddAsync(placard);
        }

        public async Task<List<Placard>> GetAllPlacardsAsync()
        {
            return await context.Placards.Include(i => i.Supporters).AsNoTracking().ToListAsync();
        }

        public async Task<Placard> GetSpecificPlacardAsync(int id)
        {
            return await context.Placards.Include(i => i.Supporters).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Placard>> GetPlacardsByNameAsync(string name)
        {
            return await context.Placards.Include(i => i.Supporters).Where(i => i.Name.ToLower().Contains(name.ToLower())).AsNoTracking().ToListAsync();
        }

        public async Task DeletePlacardAsync(int id)
        {
            var placard = await GetSpecificPlacardAsync(id);
            context.Placards.Remove(placard);
        }

        public void UpdatePlacard(Placard placard)
        {
            context.Entry(placard).State = EntityState.Modified;
        }

    }
}
