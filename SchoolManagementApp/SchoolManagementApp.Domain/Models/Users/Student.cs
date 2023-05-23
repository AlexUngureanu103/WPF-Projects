using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Domain.Models
{
    public class Student : BaseEntity
    {
        private int? userId;
        [Required]
        public int? UserId
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

        private int? classId;
        [Required]
        public int? ClassId
        {
            get { return classId; }
            set { classId = value; NotifyPropertyChanged("ClassId"); }
        }

        private Class classs;
        public Class Class
        {
            get { return classs; }
            set { classs = value; NotifyPropertyChanged("Class"); }
        }

        private List<Grade> grades;
        public List<Grade> Grades
        {
            get { return grades; }
            set { grades = value; NotifyPropertyChanged("Grades"); }
        }
    }
}
