using ManagementTask.Domain.ModelsDTO.TaskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Business.TaskService
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAll();
        Task<List<TaskDTO>> GetIsActived();
        Task<TaskDTO> Update(TaskDTO task);
        Task<TaskDTO> Delete(TaskDelete delete);
        Task<TaskDTO> Create(TaskCreate taskCreate);
    }
}
