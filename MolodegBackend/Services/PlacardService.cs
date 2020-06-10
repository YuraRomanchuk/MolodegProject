using MolodegBackend.Domain.Repositories;
using MolodegBackend.Domain.Services;
using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Services
{
    public class PlacardService : IPlacardService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPlacardRepository placardRepository;

        public PlacardService(IPlacardRepository placardRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.placardRepository = placardRepository;
        }

        public async Task AddPlacardAsync(Placard placard)
        {
            await placardRepository.AddPlacardAsync(placard);
            await unitOfWork.CompleteAsync();
        }

        public async Task<List<Placard>> GetAllPlacardAsync()
        {
            return await placardRepository.GetAllPlacardsAsync();
        }

        public async Task DeletePlacardAsync(int id)
        {
            await placardRepository.DeletePlacardAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdatePlacardAsync(Placard placard)
        {
            placardRepository.UpdatePlacard(placard);
            await unitOfWork.CompleteAsync();
        }

        public async Task<Placard> GetSpecificPlacardAsync(int id)
        {
            return await placardRepository.GetSpecificPlacardAsync(id);
        }

        public async Task<List<Placard>> GetPlacardsByNameAsync(string name)
        {
            return await placardRepository.GetPlacardsByNameAsync(name);
        }
    }
}
