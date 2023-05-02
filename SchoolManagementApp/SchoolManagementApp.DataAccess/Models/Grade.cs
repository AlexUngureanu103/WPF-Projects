namespace SchoolManagementApp.DataAccess.Models
{
    internal class Grade : BaseEntity
    {
        public int value { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        public int StudentId { get; set; }
        
    }
}
