using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class Student : BaseEntity
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

        private DateTime dateOfBirth;
        [Required]
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; NotifyPropertyChanged("DateOfBirth"); }
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

        private int classId;
        [Required]
        public int ClassId
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

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; NotifyPropertyChanged("Address"); }
        }
    }
}
