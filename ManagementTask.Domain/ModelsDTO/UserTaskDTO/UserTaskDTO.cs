using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Domain.ModelsDTO.UserTaskDTO
{
    public class UserTaskDTO
    {
        public int UserTaskId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TaskId { get; set; }
    }
}
