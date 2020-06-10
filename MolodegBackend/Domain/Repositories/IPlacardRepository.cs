using MolodegBackend.Models;
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
        void UpdatePlacard(Placard placard);
        Task<List<Placard>> GetPlacardsByNameAsync(string name);
    }
}
