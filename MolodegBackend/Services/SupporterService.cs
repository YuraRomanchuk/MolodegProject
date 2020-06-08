using MolodegBackend.Domain.Repositories;
using MolodegBackend.Domain.Services;
using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Services
{
    public class SupporterService : ISupporterService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISupporterRepository supporterRepository;

        public SupporterService(ISupporterRepository supporterRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.supporterRepository = supporterRepository;
        }

        public async Task UpdateSupporter(Supporter supporter)
        {
            supporterRepository.UpdateSupporter(supporter);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteSupporterAsync(string userId, int placardId)
        {
            await supporterRepository.DeleteSupporterAsync(userId, placardId);
            await unitOfWork.CompleteAsync();
        }

        public async Task<Supporter> GetSupporterAsync(string userId, int placardId)
        {
            return await supporterRepository.GetSupporterAsync(userId, placardId);
        }
    }
}
