using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Domain.Services
{
    public interface IPlacardService
    {
        Task AddPlacardAsync(Placard placard);
        Task<List<Placard>> GetAllPlacardAsync();
        Task DeletePlacardAsync(int id);
        public Task UpdatePlacardAsync(Placard placard);
        Task<Placard> GetSpecificPlacardAsync(int id);
    }
}
