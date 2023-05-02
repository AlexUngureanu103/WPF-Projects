namespace SchoolManagementApp.DataAccess.Models
{
    internal class CourseClass : BaseEntity
    {
        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
