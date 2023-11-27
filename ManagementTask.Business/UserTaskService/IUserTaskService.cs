using ManagementTask.Domain.ModelsDTO.UserTaskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Business.UserTaskService
{
    public interface IUserTaskService
    {
        Task<List<UserTaskDTO>> GetAll();
        Task<UserTaskDTO> Update(UserTaskDTO user);
        Task<UserTaskDTO> Delete(UserTaskDelete delete);
        Task<UserTaskDTO> Create(UserTaskCreate userTaskCreate);
    }
}
