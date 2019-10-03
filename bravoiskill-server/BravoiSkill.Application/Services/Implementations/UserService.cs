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
using System.Threading.Tasks;

namespace BravoiSkill.Application.Services.Implementations
{
    public class UserService : IUserService
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
            var user = GetAll()
                .FirstOrDefault(x => x.Email == email && x.Password == password);
            // almost always use FirstOrDefault, SingleOrDefault is kk

            if (user == null) 
                return null;
            //succesfull authentification => generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),
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
            //return users with password
            var usersDb = _userRepository.GetListOfUsers();
            var usersDto = usersDb
                .Select(userDb => _mapper.Map<User>(userDb))
                .ToList();

            return usersDto;
        }

        public User GetById(int id)
        {
            var userDb = _userRepository.GetUserById(id);
            return _mapper.Map<User>(userDb);
        }

        public void Create(User user)
        {
            user.Validate();
            if (user.HasErrors)
                throw new Exception(user.Errors[0]);

            user.Password = "123456";
            var userEntity = _mapper.Map<Domain.Entities.Users.User>(user);
            _userRepository.Create(userEntity);
        }

        public async Task Edit(int id, User user)
        {
            user.Validate();
            if (user.HasErrors)
                throw new Exception(user.Errors[0]);

            var userEntity = _userRepository.GetUserById(id);
            if (userEntity == null)
                throw new Exception("User does not exist in database");
            user.UserId = userEntity.UserId;
            user.ProfileId = userEntity.ProfileId;
            user.BadgeId = userEntity.BadgeId;

            _mapper.Map<User, Domain.Entities.Users.User>(user, userEntity);
            _userRepository.Update(userEntity);
        }

    }
}

