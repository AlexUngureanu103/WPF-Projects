﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    public class Class : BaseEntity
    {
        private string name;
        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }

        private int specializationId;
        [Required]
        public int SpecializationId
        {
            get { return specializationId; }
            set { specializationId = value; NotifyPropertyChanged("SpecializationId"); }
        }

        private Specialization specialization;
        public Specialization Specialization
        {
            get { return specialization; }
            set { specialization = value; NotifyPropertyChanged("Specialization"); }
        }

        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
            set { students = value; NotifyPropertyChanged("Students"); }
        }

        private List<CourseClass> courses;
        public List<CourseClass> Courses
        {
            get { return courses; }
            set { courses = value; NotifyPropertyChanged("Courses"); }
        }

        private int studentCount;
        [NotMapped]
        public int StudentCount
        {
            get { return studentCount; }
            set { studentCount = value; NotifyPropertyChanged("StudentCount"); }
        }
    }
}
