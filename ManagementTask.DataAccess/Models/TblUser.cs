using System;
using System.Collections.Generic;

namespace ManagementTask.DataAccess.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public Guid UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
