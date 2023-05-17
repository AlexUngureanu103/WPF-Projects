using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Domain.Models
{
    public class Person : BaseEntity
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

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; NotifyPropertyChanged("Address"); }
        }
    }
}
