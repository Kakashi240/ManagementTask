using ManagementTask.Business.UserService;
using ManagementTask.Business.UserTaskService;
using ManagementTask.Domain.ModelsDTO.UserTaskDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTask.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;
        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserTaskDTO>>> GetAll() => Ok(await _userTaskService.GetAll());

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UserTaskDTO>> Update(UserTaskDTO userTask) => Ok(await _userTaskService.Update(userTask));

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<UserTaskDTO>> Delete(UserTaskDelete delete) => Ok(await _userTaskService.Delete(delete));

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserTaskDTO>> Create(UserTaskCreate userTaskCreate) => Ok(await _userTaskService.Create(userTaskCreate));
    }
}
