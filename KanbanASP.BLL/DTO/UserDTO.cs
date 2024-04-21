using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanASP.BLL.DTO
{
    public class UserDTO
    {
        public Guid ID_User { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
