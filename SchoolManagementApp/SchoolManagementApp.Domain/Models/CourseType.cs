using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Domain.Models
{
    public class CourseType : BaseEntity
    {
        private string course;
        [Required]
        public string Course
        {
            get { return course; }
            set { course = value; NotifyPropertyChanged("Course"); }
        }
    }
}
