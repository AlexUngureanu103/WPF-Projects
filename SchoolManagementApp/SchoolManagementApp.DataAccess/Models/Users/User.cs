using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class User : BaseEntity
    {
        private int roleId;
        [Required]
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; NotifyPropertyChanged("RoleId"); }
        }

        private Role role;
        public Role Role
        {
            get { return role; }
            set { role = value; NotifyPropertyChanged("Role"); }
        }

        private string email;
        [Required]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set { email = value; NotifyPropertyChanged("Email"); }
        }

        private string passwordHash;
        [Required]
        public string PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; NotifyPropertyChanged("PasswordHash"); }
        }
    }
}
