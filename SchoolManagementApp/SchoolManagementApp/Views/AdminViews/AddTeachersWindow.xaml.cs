using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for AddTeachersWindow.xaml
    /// </summary>
    public partial class AddTeachersWindow : UserControl
    {
        private readonly Frame AdminControl;

        private readonly SchoolManagementDbContext _dbContext;

        public AddTeachersWindow(Frame AdminControl, SchoolManagementDbContext dbContext)
        {
            this.AdminControl = AdminControl ?? throw new ArgumentNullException(nameof(AdminControl));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
            PersonRepository personRepository = new PersonRepository(dbContext);
            var result = personRepository.GetAll();
            string str = string.Empty;

            foreach (var person in result)
            {
                str += $"{person.FirstName}  {person.LastName}  {person.Address}  {person.Id} \n";
            }

            MessageBox.Show(str, "Info");
        }
    }
}
