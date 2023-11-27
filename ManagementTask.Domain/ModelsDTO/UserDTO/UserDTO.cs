using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Domain.ModelsDTO.UserDTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
