using Microsoft.AspNetCore.Mvc;
using Models.Dtos.DotsRequest;
using Models.Entities;
using Services;
using Services.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Server_pdi.V1.Controllers.LoginController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IRepository _repository;
        public LoginController(IRepository repository)
        {
            _repository = repository;
        }

        //Logar Usuário
        [HttpPost("/Login")]
        [SwaggerOperation(
         Summary = "Logar Usuário",
         Description = "Logar Usuário",
         OperationId = "login.LogarUsuario",
         Tags = new[] { "LoginEndpoints" })
        ]

        public async Task<ActionResult> HandleLogin(LoginRequestDto request)
        {
            try
            {
                var user = await _repository.GetByLoginAsync<User>(request.Login);
                if (user == null || user.Deletada == true) return BadRequest("Login não encontrado");
                var encryptedPassword = new Cryptography();
                if (user.Password == encryptedPassword.Encrypt(request.Password))
                {
                    //var token = TokenService.GenerateToken(user);
                    //return Ok(LoginResponse.Response(user, token));
                    return Ok();
                }
                else
                {
                    //retorna que a senha passada está errada
                    return BadRequest("Senha não confere");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
