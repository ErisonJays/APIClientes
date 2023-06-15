using APIClientes.Modelos;
using APIClientes.Modelos.Dto;
using APIClientes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        protected ResponseDto _response;

        public UsersController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
            _response = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult>  Register(UserDto user)
        {
            var respuesta = await _userRepositorio.Register(

                new User
                {
                    UserName = user.UserName
                }, user.PassWord);

            if(respuesta == -1)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya Existe";
                return BadRequest(_response);
            }

            if(respuesta == -500)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el usuario";
                return BadRequest(_response);
            }
            _response.DisplayMessage = "Usuario Creado con Exito";
            _response.Result = respuesta;   
            return Ok(_response);

        }
        [HttpPost("Login")]
        public async Task<ActionResult>Login(UserDto user)
        {
            var respuesta = await _userRepositorio.Login(user.UserName, user.PassWord);
            if (respuesta == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no Existe";
                return BadRequest(_response);
            }
            if(respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Clave incorrecta";
                return BadRequest(_response);
            }
            _response.Result = respuesta;
            _response.DisplayMessage = "Usuario Conectado";
            return Ok(_response);

        }

    }
}
