using System;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    internal class Absences : BaseEntity
    {
        public DateTime Date { get; set; }

        public bool IsMotivated { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }
    }
}
