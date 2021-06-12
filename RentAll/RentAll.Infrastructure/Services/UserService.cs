using RentAll.Domain;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Services
{
 public class UserService:IUserService
    {
        #region fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region constructors
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion
        #region public methods
        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
        #endregion
    }
}
