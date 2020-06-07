using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}
