using Microsoft.EntityFrameworkCore;
using MolodegBackend.Domain.Repositories;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }
        
        public void UpdateUserAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public async Task<User> GetUserAsync(string userId)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(i => i.Id == userId);
        }

        public async Task<UserInfo> GetUserInfo(string userId)
        {
            return await context.Users.Where(i => i.Id == userId).AsNoTracking().Select(i =>
                new UserInfo()
                {
                    CreatedDate = i.CreatedDate,
                    Access = i.Access,
                    Description = i.Description,
                    Name = i.Name,
                    Placards = i.Placards,
                    ProfilePicture = i.ProfilePicture
                }).FirstOrDefaultAsync();
        }
    }
}
