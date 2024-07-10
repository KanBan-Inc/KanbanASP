namespace KanbanASP.Models
{
    public class UserViewModel
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
