using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Domain.Services
{
    public interface IUserService
    {
        Task UpdateUserAsync(User user);
        Task<User> GetUserAsync(string userId);
        Task<UserInfo> GetUserInfoAsync(string userId);
    }
}
