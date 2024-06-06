
using System.Collections.Generic;

namespace KanbanASP.DAL.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
