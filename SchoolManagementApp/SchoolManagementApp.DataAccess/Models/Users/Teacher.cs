using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class Teacher : BaseEntity
    {
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

        private List<CourseClass> teachingClasses;
        public List<CourseClass> TeachingClasses
        {
            get { return teachingClasses; }
            set { teachingClasses = value; NotifyPropertyChanged("TeachingClasses"); }
        }
    }
}
