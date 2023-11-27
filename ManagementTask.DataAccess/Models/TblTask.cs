using System;
using System.Collections.Generic;

namespace ManagementTask.DataAccess.Models
{
    public partial class TblTask
    {
        public TblTask()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public Guid TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string TaskDescription { get; set; } = null!;
        public DateTime TaskDate { get; set; }
        public bool IsComplete { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
