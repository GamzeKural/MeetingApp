using MeetingApp.Business.Abstracts;
using MeetingApp.DataAccess.Abstracts;
using MeetingApp.Entities.Models;
using MeetingApp.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Business.Concretes
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration config;
        private readonly IRepository repo;
        public TokenService(IConfiguration config, IRepository repo)
        {
            this.config = config;
            this.repo = repo;
        }
        public Token Authenticate(AuthModel model)
        {
            var users = repo.GetAll<User>().ToList();

            if (!users.Any(x => (x.Mail == model.Mail && Encription.Decrypt(x.Password) == model.Password)))
            {
                return null;
            }

            var userData = users.FirstOrDefault(x => (x.Mail == model.Mail && Encription.Decrypt(x.Password) == model.Password));

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token { VerifiedToken = tokenHandler.WriteToken(token) };

        }
    }
}
