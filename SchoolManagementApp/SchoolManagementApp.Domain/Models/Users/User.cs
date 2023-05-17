using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Domain.Models
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

        private int PersonId;
        public int personId
        {
            get { return PersonId; }
            set { PersonId = value; NotifyPropertyChanged("PersonId"); }
        }

        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value; NotifyPropertyChanged("Person"); }
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
