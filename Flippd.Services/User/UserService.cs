using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data;
using Flippd.Data.Entities;
using Flippd.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Flippd.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if(await GetUserByEmailAsync(model.Email) != null || await GetUserByEmailAsync(model.Username) != null)
            return false;

            var entity = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };
            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        private async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        }

        public async Task<UserDetail> GetUserByIdAsync(int userId)
        {
            var entity = await _context.Users.Include(r => r.MyListings).FirstOrDefaultAsync(e => e.Id == userId);
            // Need to use .Include with lamba expression before the request looks for the object by Id specified, so it can have the MyListings information to access once it arrives to the location we are pointing it to.
            if(entity is null)
            return null;

            var userDetail = new UserDetail
            {
                Id = entity.Id,
                Email = entity.Email,
                Username = entity.Username,
                PhoneNumber = entity.PhoneNumber,
                MyListings = entity.MyListings
            };

            return userDetail;
        }

        
    }
}