using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepositories.get(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Usuario ou senha invalidos" });

            //Gera o Token
            var token = TokenService.GenerateToken(user);

            //Limpa Senha
            user.Password = "";

            //Retorna dados
            return new
            {
                user = user,
                token = token
            };

        }
    }
}
