using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Domain.Models
{
    public class Role : BaseEntity
    {
        private string assignedRole;
        [Required]
        public string AssignedRole
        {
            get { return assignedRole; }
            set { assignedRole = value; NotifyPropertyChanged("AssignedRole"); }
        }
    }
}
