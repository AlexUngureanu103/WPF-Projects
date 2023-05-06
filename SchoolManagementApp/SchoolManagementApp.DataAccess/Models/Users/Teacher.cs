using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class Teacher : BaseEntity
    {
        private string firstName;
        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; NotifyPropertyChanged("FirstName"); }
        }

        private string lastName;
        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; NotifyPropertyChanged("LastName"); }
        }

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

        private DateTime dateOfBirth;
        [Required]
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; NotifyPropertyChanged("DateOfBirth"); }
        }

        private List<CourseClass> teachingClasses;
        public List<CourseClass> TeachingClasses
        {
            get { return teachingClasses; }
            set { teachingClasses = value; NotifyPropertyChanged("TeachingClasses"); }
        }
    }
}
