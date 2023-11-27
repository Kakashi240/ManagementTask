using ManagementTask.Business.TaskService;
using ManagementTask.Domain.ModelsDTO.TaskDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTask.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TaskDTO>>> GetAll() => Ok(await _taskService.GetAll());

        [HttpGet("IsActived")]
        [Authorize]
        public async Task<ActionResult<List<TaskDTO>>> GetIsActived() => Ok(await _taskService.GetIsActived());

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<TaskDTO>> Update(TaskDTO task) => Ok(await _taskService.Update(task));

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<TaskDTO>> Delete(TaskDelete delete) => Ok(await _taskService.Delete(delete));

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TaskDTO>> Create(TaskCreate taskCreate) => Ok(await _taskService.Create(taskCreate));
    }
}
