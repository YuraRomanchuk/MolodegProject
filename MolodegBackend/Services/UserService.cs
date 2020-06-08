using MolodegBackend.Domain.Repositories;
using MolodegBackend.Domain.Services;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public async Task UpdateUserAsync(User user)
        {
            userRepository.UpdateUserAsync(user);
            await unitOfWork.CompleteAsync();
        }

        public async Task<User> GetUserAsync(string userId)
        {
            return await userRepository.GetUserAsync(userId);
        }

        public async Task<UserInfo> GetUserInfoAsync(string userId)
        {
            return await userRepository.GetUserInfo(userId);
        }
    }
}
