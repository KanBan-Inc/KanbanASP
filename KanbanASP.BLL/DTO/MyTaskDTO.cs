using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanASP.BLL.DTO
{
    public class MyTaskDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
