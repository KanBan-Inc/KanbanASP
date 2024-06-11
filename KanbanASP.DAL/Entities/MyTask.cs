
using System.Collections.Generic;

namespace KanbanASP.DAL.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
