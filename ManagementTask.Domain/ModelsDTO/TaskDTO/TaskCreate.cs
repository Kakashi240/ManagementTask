using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Domain.ModelsDTO.TaskDTO
{
    public class TaskCreate
    {
        public string TaskName { get; set; } = null!;
        public string TaskDescription { get; set; } = null!;
        public DateTime TaskDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
