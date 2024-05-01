using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication3.Utils
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123askdhaskd12u3heasjkdaksjbhdhj";   // ключ для шифрации
        public const int LIFETIME = 30; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
