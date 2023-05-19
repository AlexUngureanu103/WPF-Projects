using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels;
using SchoolManagementApp.Views.ClassMasterViews;
using SchoolManagementApp.Views.TeacherViews;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for ClassMasterUserControl.xaml
    /// </summary>
    public partial class ClassMasterUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly ClassMasterUserControlVM ClassMasterUserControlVM;

        private readonly IUserControlFactory _userControlFactory;

        public ClassMasterUserControl(Frame windowContainer, IUserControlFactory userControlFactory, ClassMasterUserControlVM classMasterUserControlVM)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _userControlFactory = userControlFactory ?? throw new ArgumentNullException(nameof(userControlFactory));
            ClassMasterUserControlVM = classMasterUserControlVM ?? throw new ArgumentNullException(nameof(classMasterUserControlVM));

            InitializeComponent();

            DataContext = ClassMasterUserControlVM;
        }


        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageGradesTeacherControl>());
        }

        private void Absences_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageAbsencesTeacherControl>());
        }
        private void Students_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageStudentsTeacherControl>());
        }
        
        private void Materials_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageMaterialsTeacherControl>());
        } 

        private void OwnAbsences_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageAbsencesClassMasterControl>());
        }

        private void FinalGrades_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageFinalGradesClassMasterControl>());
        }

        private void Top_Click(object sender, RoutedEventArgs e)
        {
            //TeacherControls.Navigate(_userControlFactory.Create<ManageOwnClassClassMasterControl>());
        }

        private void ExmatriculareClick(object sender, RoutedEventArgs e)
        {
            //TeacherControls.Navigate(_userControlFactory.Create<ManageOwnClassClassMasterControl>());
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (WindowContainer.CanGoBack)
            {
                while (WindowContainer.CanGoBack)
                {
                    WindowContainer.RemoveBackEntry();
                }
                WindowContainer.Navigate(_userControlFactory.Create<LoginWindow>());
            }
            else
            {
                throw new ArgumentException("Invalid  navigation operation");
            }
        }
    }
}
