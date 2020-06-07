using Microsoft.EntityFrameworkCore;
using MolodegBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }
        
    }
}
