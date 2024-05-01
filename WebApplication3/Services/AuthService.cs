using System.Security.Claims;
using System;
using WebApplication3.Utils;
using WebApplication3.Models;
using Microsoft.IdentityModel.JsonWebTokens;

namespace WebApplication3.Services
{
    public class AuthService
    {
        public bool TryLoggingIn(string login, string password)
        {
            var candidate = Database.Context.Customers.Where(c => c.Login == login && c.Password == password).FirstOrDefault();

            return candidate != null;
        }

        public Customer GetMe(string login)
        {
            var candidate = Database.Context.Customers.Where(c => c.Login == login).FirstOrDefault();

            if (candidate == null)
            {
                throw new Exception("Пользователя с таким логином не найдено");
            }

            return candidate;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            Customer person = Database.Context.Customers.FirstOrDefault(x => x.Login == username && x.Password == password);

            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
