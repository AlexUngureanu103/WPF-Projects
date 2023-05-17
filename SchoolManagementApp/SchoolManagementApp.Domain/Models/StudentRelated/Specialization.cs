namespace SchoolManagementApp.Domain.Models.StudentRelated
{
    public class Specialization : BaseEntity
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
    }
}
