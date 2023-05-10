using Autofac;
using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Repositories;
using SchoolManagementApp.Services.RepositoryServices;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using SchoolManagementApp.ViewModels;
using SchoolManagementApp.ViewModels.AdminControls;
using SchoolManagementApp.ViewModels.AdminControls.ManageSpecializationVMs;
using SchoolManagementApp.ViewModels.AdminControls.ManageStudentVMs;
using SchoolManagementApp.ViewModels.AdminControls.ManageUserVMs;
using SchoolManagementApp.Views;
using SchoolManagementApp.Views.AdminViews;
using SchoolManagementApp.Views.AdminViews.ManageStudentsViews;
using System.Configuration;
using System.Windows.Controls;

namespace SchoolManagementApp.Services
{
    internal class Bootstrapper
    {
        public IUserControlFactory Run(Frame frame)
        {
            using(var scope = BuildApplication(frame).BeginLifetimeScope())
            {
                var UserControlFactory = scope.Resolve<IUserControlFactory>();
                return UserControlFactory;
            }
        }
        private static IContainer BuildApplication( Frame frame)
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);
            RegisterRepositories(builder);
            RegisterMainUsersPage(builder);
            RegisterAdminControls(builder);
            RegisterWindows(builder);
            RegisterCommands(builder);

            builder.RegisterType<UnitOfWork>().AsSelf().SingleInstance();
            string connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;
            builder.Register(ctx => new SchoolManagementDbContext(connectionString)).AsSelf().SingleInstance();
            builder.Register(ctx => LogHelper.GetLogger()).As<log4net.ILog>();
            builder.RegisterType<UserControlFactory>().As<IUserControlFactory>().SingleInstance();
            builder.Register(ctx => frame).AsSelf().SingleInstance();

            return builder.Build();
        }
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ClassService>().As<IClassService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<GradeService>().As<IGradeService>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<SpecializationCourseService>().As<ISpecializationCourseService>();
            builder.RegisterType<SpecializationService>().As<ISpecializationService>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<AuthorizationService>().AsSelf();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ClassRepository>().As<IClassRepository>().SingleInstance();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().SingleInstance();
            builder.RegisterType<GradeRepository>().As<IGradeRepository>().SingleInstance();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().SingleInstance();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().SingleInstance();
            builder.RegisterType<SpecializationCourseRepository>().As<ISpecializationCourseRepository>().SingleInstance();
            builder.RegisterType<SpecializationRepository>().As<ISpecializationRepository>().SingleInstance();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
        }

        private static void RegisterMainUsersPage(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherUserControlVM>().AsSelf().SingleInstance();
            builder.RegisterType<StudentUserControlVM>().AsSelf().SingleInstance();
            builder.RegisterType<LoginWindowVM>().AsSelf().SingleInstance();
            builder.RegisterType<ClassMasterUserControlVM>().AsSelf().SingleInstance();
        }

        private static void RegisterAdminControls(ContainerBuilder builder)
        {
            builder.RegisterType<ManageSpecializationCourseVM>().AsSelf().SingleInstance();
            builder.RegisterType<ManagePersonsVM>().AsSelf().SingleInstance();
            builder.RegisterType<ManageCoursesVM>().AsSelf().SingleInstance();
            builder.RegisterType<ManageClassesVM>().AsSelf().SingleInstance();

            builder.RegisterType<ManageUsersVM>().AsSelf().SingleInstance();
            builder.RegisterType<AddUsersWindowVM>().AsSelf().SingleInstance();

            builder.RegisterType<ManageStudentsVM>().AsSelf().SingleInstance();

            builder.RegisterType<ManageSpecializationsVM>().AsSelf().SingleInstance();
        }

        private static void RegisterWindows(ContainerBuilder builder)
        {
            builder.RegisterType<LoginWindow>().AsSelf();

            builder.RegisterType<TeacherUserControl>().AsSelf();
            builder.RegisterType<StudentUserControl>().AsSelf();
            builder.RegisterType<ClassMasterUserControl>().AsSelf();
            builder.RegisterType<AdminUserControl>().AsSelf();

            builder.RegisterType<LoginWindow>().AsSelf();

            RegisterAdminViews(builder);
        }

        private static void RegisterAdminViews(ContainerBuilder builder)
        {
            builder.RegisterType<ManageUsers>().AsSelf();
            builder.RegisterType<ManageStudentsAdminControl>().AsSelf();
            builder.RegisterType<ManageSpecializationsAdminControl>().AsSelf();
            builder.RegisterType<ManageSpecializationCourseAdminControl>().AsSelf();
            builder.RegisterType<ManagePersonsAdminCrontrol>().AsSelf();
            builder.RegisterType<ManageCoursesAdminControl>().AsSelf();
            builder.RegisterType<ManageClasses>().AsSelf();

            builder.RegisterType<AddUsersWindow>().AsSelf();
            builder.RegisterType<AddTeachersWindow>().AsSelf();
            builder.RegisterType<AddStudentsWindow>().AsSelf();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<DeleteStudentsCommands>().AsSelf().SingleInstance();
            builder.RegisterType<DeleteUserCommands>().AsSelf().SingleInstance();
            builder.RegisterType<ManageSpecializationsCommands>().AsSelf().SingleInstance();
            builder.RegisterType<ManageUsersCommands>().AsSelf().SingleInstance();
        }
    }
}
