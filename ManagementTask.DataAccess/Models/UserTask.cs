using System;
using System.Collections.Generic;

namespace ManagementTask.DataAccess.Models
{
    public partial class UserTask
    {
        public int UserTaskId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TaskId { get; set; }

        public virtual TblTask? Task { get; set; }
        public virtual TblUser? User { get; set; }
    }
}
