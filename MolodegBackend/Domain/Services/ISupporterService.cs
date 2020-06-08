using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Domain.Services
{
    public interface ISupporterService
    {
        Task UpdateSupporter(Supporter supporter);
        Task DeleteSupporterAsync(string userId, int placardId);
        Task<Supporter> GetSupporterAsync(string userId, int placardId);
    }
}
