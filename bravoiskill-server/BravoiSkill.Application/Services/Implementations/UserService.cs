using AutoMapper;
using BravoiSkill.Application.DTO.Users;
using BravoiSkill.Application.Services.Interfaces;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BravoiSkill.Application.Services.Implementations
{
    class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, 
            IUserRepository userRepository,
            IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetAll().SingleOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
                return null;
            //succesfull authentification => generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            //remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            //return users without password
            var usersDb = _userRepository.GetListOfUsers();
            var usersDto = usersDb
                .Select(userDb => _mapper.Map<User>(usersDb))
                .ToList();

            return usersDto;
        }

    }
}

