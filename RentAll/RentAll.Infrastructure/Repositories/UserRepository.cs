using Microsoft.EntityFrameworkCore;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        #region CRUD user
        public List<User> GetUsers()
        {
            return _rentAllDbContext.Users.ToList();
        }
        public User GetUserById(int userId)
        {
            return _rentAllDbContext.Users.Find(userId);
        }


        public void InsertUser(User user)
        {
            _rentAllDbContext.Users.Add(user);
            Save();
        }



        public void UpdateUser(User user)
        {
            _rentAllDbContext.Users.Attach(user);
            var entry = _rentAllDbContext.Entry(user);
            entry.State = EntityState.Modified;

            Save();
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            _rentAllDbContext.Users.Remove(user);
            Save();
        }

        #endregion

        #region CRUD role




        #endregion

        public void Save()
        {
            _rentAllDbContext.SaveChanges();
        }

        #endregion
    }
}
