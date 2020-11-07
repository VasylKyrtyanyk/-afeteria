using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Сafeteria.DataModels.Entities;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.ModelsDTO;
using Сafeteria.Services;
using Сafeteria.Services.Helpers;
using BC = BCrypt.Net.BCrypt;

namespace Сafeteria.Infrastructure.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> Authenticate(string email, string password)
        {
            var user = (await _unitOfWork.UserRepository.GetAll()).SingleOrDefault(x => x.Email == email && BC.Verify(password, x.Password));

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            await _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<bool> Register(UserDTO user)
        {
            // hash password
            user.Password = BC.HashPassword(user.Password);
            var result = await _unitOfWork.UserRepository.Register(_mapper.Map<UserDTO, User>(user));
            return result;
        }
    }
}
