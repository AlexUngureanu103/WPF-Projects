using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    internal class Grade : BaseEntity
    {
        [Required]
        [Range(1, 10)]
        public int Value { get; set; }

        public bool IsThesis { get; set; }

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
