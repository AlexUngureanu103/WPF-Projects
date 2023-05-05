using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Models
{
    public class SpecializationCourse : BaseEntity
    {
        public int SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        public bool HasThesis { get; set; }
    }
}
