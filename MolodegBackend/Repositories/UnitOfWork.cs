using MolodegBackend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Repositories
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        public UnitOfWork(AppDbContext context) : base(context) { }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
