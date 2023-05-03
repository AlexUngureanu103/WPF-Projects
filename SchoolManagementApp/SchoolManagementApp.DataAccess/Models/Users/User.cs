namespace SchoolManagementApp.DataAccess.Models
{
    internal class User : BaseEntity
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
