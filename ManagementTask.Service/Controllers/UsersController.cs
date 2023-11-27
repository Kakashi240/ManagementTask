using ManagementTask.Business.UserService;
using ManagementTask.Domain.ModelsDTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTask.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserDTO>>> GetAll() => Ok(await _userService.GetAll());

        [HttpGet("IsActived")]
        [Authorize]
        public async Task<ActionResult<List<UserDTO>>> GetIsActived() => Ok(await _userService.GetIsActived());

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UserDTO>> Update(UserDTO user) => Ok(await _userService.Update(user));

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<UserDTO>> Delete(UserDelete delete) => Ok(await _userService.Delete(delete));

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<UserDTO>> Create(UserCreate userCreate) => Ok(await _userService.Create(userCreate));
    }
}
