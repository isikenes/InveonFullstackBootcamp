namespace LibraryManagement.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public required string Id { get; set; }
        public required string Username { get; set; }
        public required IList<string> Roles { get; set; }
        public required IList<string> AllRoles { get; set; }
    }
}
