using Autofac;
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

namespace SchoolManagementApp.Services
{
    internal class Bootstrapper
    {
        public IComponentContext Run()
        {
            return BuildApplication().BeginLifetimeScope();
        }
        private static IContainer BuildApplication()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);
            RegisterRepositories(builder);
            RegisterMainUsersPage(builder);
            RegisterAdminControls(builder);
            RegisterWindows(builder);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            string connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;
            builder.Register(ctx => new SchoolManagementDbContext(connectionString)).AsSelf().SingleInstance();
            builder.Register(ctx => LogHelper.GetLogger()).As<log4net.ILog>();
            builder.RegisterType<UserControlFactory>().As<IUserControlFactory>().SingleInstance();

            return builder.Build();
        }
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ClassService>().As<IClassService>().SingleInstance();
            builder.RegisterType<CourseService>().As<ICourseService>().SingleInstance();
            builder.RegisterType<GradeService>().As<IGradeService>().SingleInstance();
            builder.RegisterType<PersonService>().As<IPersonService>().SingleInstance();
            builder.RegisterType<SpecializationCourseService>().As<ISpecializationCourseService>().SingleInstance();
            builder.RegisterType<SpecializationService>().As<ISpecializationService>().SingleInstance();
            builder.RegisterType<StudentService>().As<IStudentService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            builder.RegisterType<AuthorizationService>().AsSelf().SingleInstance();
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
            builder.RegisterType<TeacherUserControlVM>().AsSelf();
            builder.RegisterType<StudentUserControlVM>().AsSelf();
            builder.RegisterType<LoginWindowVM>().AsSelf();
            builder.RegisterType<ClassMasterUserControlVM>().AsSelf();
            builder.RegisterType<AdminUserControlVM>().AsSelf();
        }

        private static void RegisterAdminControls(ContainerBuilder builder)
        {
            builder.RegisterType<ManageSpecializationCourseVM>().AsSelf();
            builder.RegisterType<ManagePersonsVM>().AsSelf();
            builder.RegisterType<ManageCoursesVM>().AsSelf();
            builder.RegisterType<ManageClassesVM>().AsSelf();

            builder.RegisterType<ManageUsersVM>().AsSelf();
            builder.RegisterType<AddUsersWindowVM>().AsSelf();

            builder.RegisterType<ManageStudentsVM>().AsSelf();

            builder.RegisterType<ManageSpecializationsVM>().AsSelf();
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
    }
}
