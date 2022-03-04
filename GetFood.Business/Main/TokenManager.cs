using GetFood.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Business.Main
{
    public class TokenManager
    {
        IConfiguration configuration;
        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public string CreateAccessToken(User user)
        {

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, user.UserId.ToString()),
                 new Claim("id", user.UserId.ToString()),
                 new Claim("email", user.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");


            var claimList = new List<Claim>
            {
                //new Claim("role", "Admin"),
                //new Claim("role2","User")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));


            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                 issuer: configuration["Tokens:Issuer"],
                 audience: configuration["Tokens:Issuer"],
                 expires: DateTime.Now.AddMinutes(5000),
                 notBefore: DateTime.Now, 
                 signingCredentials: cred,
                 claims: claimsIdentity.Claims
                );

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }




    }
}
