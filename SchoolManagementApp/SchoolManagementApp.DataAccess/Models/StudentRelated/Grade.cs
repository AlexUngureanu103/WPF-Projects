using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    public class Grade : BaseEntity
    {
        [Required]
        [Range(1, 10)]
        public int Value { get; set; }

        public bool IsThesis { get; set; }

        [Required]
        [Range(1, 2)]
        public int Semester { get; set; }

        [Required]
        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}
