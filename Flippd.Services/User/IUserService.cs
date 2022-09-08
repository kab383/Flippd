using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data.Entities;
using Flippd.Models.User;

namespace Flippd.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<UserDetail> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserInfoByIdAsync(UserUpdate request);
    }
}