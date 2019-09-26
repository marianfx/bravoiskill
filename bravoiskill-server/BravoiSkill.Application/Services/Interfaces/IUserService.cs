using BravoiSkill.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
    }   
}
