using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Domain.Repositories
{
    public interface ISupporterRepository
    {
        Task DeleteSupporterAsync(string userId, int placardId);
        void UpdateSupporter(Supporter supporter);
        Task<Supporter> GetSupporterAsync(string userId, int placardId);
    }
}
