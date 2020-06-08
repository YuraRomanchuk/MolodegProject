using Microsoft.EntityFrameworkCore;
using MolodegBackend.Domain.Repositories;
using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Repositories
{
    public class SupporterRepository : BaseRepository, ISupporterRepository
    {
        public SupporterRepository(AppDbContext context) : base(context)
        { }

        public void UpdateSupporter(Supporter supporter)
        {
            context.Supporter.Update(supporter);
        }

        public async Task DeleteSupporterAsync(string userId, int placardId)
        {
            var supporter = await GetSupporterAsync(userId, placardId);
            if (supporter != null)
            {
                context.Supporter.Remove(supporter);
            }
        }

        public async Task<Supporter> GetSupporterAsync(string userId, int placardId)
        {
            return await context.Supporter.FirstOrDefaultAsync(i => i.UserId == userId && i.CardId == placardId);
        }
    }
}
