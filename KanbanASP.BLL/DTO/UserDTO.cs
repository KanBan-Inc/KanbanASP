using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanASP.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Password { get; set; }
        public bool AdminRights { get; set; }
        public bool BossRights { get; set; }
    }
}
