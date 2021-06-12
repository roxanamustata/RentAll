using Microsoft.EntityFrameworkCore;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        #region fields
        private readonly RentAllDbContext _rentAllDbContext;
        #endregion

        #region constructors
        public UserRepository(RentAllDbContext rentAllDbContext)
        {
            _rentAllDbContext = rentAllDbContext;
        }
        #endregion


        #region public methods


       

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                return await _rentAllDbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _rentAllDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"{nameof(CreateUserAsync)} entity must not be null");
            }

            try
            {
                await _rentAllDbContext.Users.AddAsync(user);
                await _rentAllDbContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(user)} could not be saved: {ex.Message}");
            }

        }

        public async Task UpdateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateUserAsync)} entity must not be null");
            }

            try
            {
                _rentAllDbContext.Users.Update(user);
                await _rentAllDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(user)} could not be updated: {ex.Message}");
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = _rentAllDbContext.Users.Find(userId);


            if (user != null)
            {
                _rentAllDbContext.Users.Remove(user);
                await _rentAllDbContext.SaveChangesAsync();
            }
        }

        #endregion

      
    }
}
