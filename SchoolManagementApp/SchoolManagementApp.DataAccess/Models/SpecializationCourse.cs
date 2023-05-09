using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Models
{
    public class SpecializationCourse : BaseEntity
    {
        private int specializationId;
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

        private int courseTypeId;
        public int CourseTypeId
        {
            get { return courseTypeId; }
            set { courseTypeId = value; NotifyPropertyChanged("CourseTypeId"); }
        }

        private CourseType courseType;
        public CourseType CourseType
        {
            get { return courseType; }
            set { courseType = value; NotifyPropertyChanged("CourseType"); }
        }

        private bool hasThesis;
        public bool HasThesis
        {
            get { return hasThesis; }
            set { hasThesis = value; NotifyPropertyChanged("HasThesis"); }
        }
    }
}
