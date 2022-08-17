using Microsoft.AspNetCore.Mvc;
using Models.Dtos.DtosRequest;
using Models.Dtos.DtosResponse;
using Models.Entities;
using Services.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Server_pdi.V1.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository _repository;
        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("/User/Registration")]
        //[Authorize(Roles = "ADM")]
        [SwaggerOperation(
         Summary = "Criar Usuário",
         Description = "Criar Usuário",
         OperationId = "Usuario.CriarUsuario",
         Tags = new[] { "UserEndpoints" })
        ]

        public async Task<ActionResult> HandlePostUser(UserRequestPostDto request)
        {
            try
            {
                var user = await _repository.ListAsync<User>();
                if (user.Where(y => y.Login == request.Login && y.Deletada == false).Any()) return BadRequest("Usuário já é cadatrado");
                var newUser = new User(request.Name, request.Login, request.Password, request.Role);
                var createdUser = await _repository.AddAsync(newUser);
                return CreatedAtAction(nameof(HandleGetUser), new { createdUser.Id }, UserResponseDto.Response(createdUser));
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("/User")]
        //[Authorize(Roles = "ADM")]
        [SwaggerOperation(
            Summary = "Buscar todos usuários",
            Description = "Buscar Usuario",
            OperationId = "Usuários.BuscarTodosUsuários",
            Tags = new[] { "UserEndpoints" })
        ]
        public async Task<ActionResult> HandleGetAllUsers()
        {
            try
            {
                var users = await _repository.ListAsync<User>();
                users = users.Where(x => x.Deletada != true).ToList();
                if (users == null) return NotFound("Não foi encontrado nenhum usuário");
                return Ok(new UsersResponseDto(users));
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        //Buscar um único usuário
        [HttpGet("/User/{id:Guid}")]
        //[Authorize(Roles = "ADM,USER")]
        [SwaggerOperation(
         Summary = "Buscar um único Usuario",
         Description = "Buscar um único Usuario",
         OperationId = "Usuario.BuscarUsuario",
         Tags = new[] { "UserEndpoints" })
        ]
        public async Task<ActionResult> HandleGetUser(Guid id)
        {
            try
            {
                var user = await _repository.GetByIdAsync<User>(id);
                if (user == null || user.Deletada == true) return NotFound($"Não foi encontrado o usuario do id= {id}");
                return Ok(UserResponseDto.Response(user));
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }


        //atualizar usuario
        [HttpPut("/User")]
        //[Authorize(Roles = "ADM")]
        [SwaggerOperation(
         Summary = "Atualiza Usuario",
         Description = "Atualiza Usuario",
         OperationId = "Usuario.AtualizaUsuario",
         Tags = new[] { "UserEndpoints" })
        ]

        public async Task<ActionResult> HandlePutUser(UserRequestPutDto request)
        {
            try
            {
                var user = await _repository.GetByIdAsync<User>(request.UserId);
                if (user == null || user.Deletada == true) return NotFound($"Não foi encontrado o usuario do id= {request.UserId}");
                user.UpdateUser(request);
                await _repository.UpdateAsync(user);
                return Ok(UserResponseDto.Response(user));
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        //Deleta um único usuário
        [HttpDelete("/User/{id:Guid}")]
        //[Authorize(Roles = "ADM")]
        [SwaggerOperation(
         Summary = "Delete Usuario",
         Description = "Delete Usuario",
         OperationId = "Usuario.DeleteUsuario",
         Tags = new[] { "UserEndpoints" })
        ]

        public async Task<ActionResult> HandleDeleteUser(Guid id)
        {
            try
            {
                var user = await _repository.GetByIdAsync<User>(id);
                if (user == null || user.Deletada == true) return NotFound($"Não foi encontrado o usuario do id= {id}");
                await _repository.DeleteLogicAsync(user);
                return Ok($"Usuario do id={id} foi excluido com sucesso");
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
