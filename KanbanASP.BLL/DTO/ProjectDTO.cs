using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanASP.BLL.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
