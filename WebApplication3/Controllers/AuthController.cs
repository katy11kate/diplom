using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using WebApplication3.ModelsDTO;
using WebApplication3.Services;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class AuthController : Controller
    {
        AuthService _authService;

        public AuthController(AuthService authService) 
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("/login")]
        public ActionResult<AuthLoginDTO> Login([FromBody] LoginDTO loginDTO)
        {
            if (!_authService.TryLoggingIn(loginDTO.Login, loginDTO.Password))
            {
                return BadRequest("Неверный логин или пароль");
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: _authService.GetIdentity(loginDTO.Login, loginDTO.Password).Claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new AuthLoginDTO() { access_token = encodedJwt });
        }

        [HttpGet]
        [Route("/me")]
        public ActionResult<AuthLoginDTO> GetMe()
        {
            var userLogin = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userLogin))
            {
                return BadRequest("Токен авторизации пуст");
            }

            var me = _authService.GetMe(userLogin);

            return Ok(new AuthLoginDTO() { access_token = encodedJwt });
        }
    }
}
