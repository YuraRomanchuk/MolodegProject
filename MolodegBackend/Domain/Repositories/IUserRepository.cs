using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Domain.Repositories
{
    public interface IUserRepository
    {
        public void UpdateUserAsync(User user);
        Task<User> GetUserAsync(string userId);
        Task<UserInfo> GetUserInfo(string userId);
    }
}
