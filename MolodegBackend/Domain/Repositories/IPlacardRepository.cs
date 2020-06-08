﻿using MolodegBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MolodegBackend.Domain.Repositories
{
    public interface IPlacardRepository
    {
        Task AddPlacardAsync(Placard placard);
        Task<List<Placard>> GetAllPlacardsAsync();
        Task<Placard> GetSpecificPlacardAsync(int id);
        Task DeletePlacardAsync(int id);
        public void UpdatePlacard(Placard placard);
    }
}
