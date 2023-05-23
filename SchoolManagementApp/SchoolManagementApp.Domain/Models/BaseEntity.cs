namespace SchoolManagementApp.Domain.Models
{
    public class BaseEntity : BasePropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
    }
}
