﻿using BravoiSkill.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);

        void Create(User user);

        Task Edit(int id, User user);
    }   
}
