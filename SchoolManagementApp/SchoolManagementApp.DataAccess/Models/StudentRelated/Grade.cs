using System;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    internal class Grade : BaseEntity
    {
        public int Value { get; set; }

        public bool IsThesis { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public DateTime Date { get; set; }

    }
}
