using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Models.Users
{
    internal class ClassMaster : BaseEntity
    {
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
