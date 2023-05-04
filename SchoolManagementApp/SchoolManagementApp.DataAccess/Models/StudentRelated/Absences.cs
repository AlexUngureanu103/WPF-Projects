using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    internal class Absences : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 2)]
        public int Semester { get; set; }

        [Required]
        public bool IsMotivated { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }
    }
}
