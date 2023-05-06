using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Models
{
    public class SpecializationCourse : BaseEntity
    {
        public int SpecializationId
        {
            get { return SpecializationId; }
            set { SpecializationId = value; NotifyPropertyChanged("SpecializationId"); }
        }

        public Specialization Specialization
        {
            get { return Specialization; }
            set { Specialization = value; NotifyPropertyChanged("Specialization"); }
        }

        public int CourseTypeId
        {
            get { return CourseTypeId; }
            set { CourseTypeId = value; NotifyPropertyChanged("CourseTypeId"); }
        }

        public CourseType CourseType
        {
            get { return CourseType; }
            set { CourseType = value; NotifyPropertyChanged("CourseType"); }
        }

        public bool HasThesis
        {
            get { return HasThesis; }
            set { HasThesis = value; NotifyPropertyChanged("HasThesis"); }
        }
    }
}
