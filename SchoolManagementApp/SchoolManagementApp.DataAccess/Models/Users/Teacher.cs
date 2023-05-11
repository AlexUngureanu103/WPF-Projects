using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class Teacher : BaseEntity
    {
        private int userId;
        [Required]
        public int UserId
        {
            get { return userId; }
            set { userId = value; NotifyPropertyChanged("UserId"); }
        }

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; NotifyPropertyChanged("User"); }
        }

        private List<CourseClassTeacher> teachingClasses;
        public List<CourseClassTeacher> TeachingClasses
        {
            get { return teachingClasses; }
            set { teachingClasses = value; NotifyPropertyChanged("TeachingClasses"); }
        }
    }
}
