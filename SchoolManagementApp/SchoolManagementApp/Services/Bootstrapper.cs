using Autofac;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Repositories;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.RepositoryServices;
using SchoolManagementApp.ViewModels;
using SchoolManagementApp.ViewModels.AdminControls;
using SchoolManagementApp.Views;
using SchoolManagementApp.Views.AdminViews;
using System.Configuration;
using System.Windows.Controls;

namespace SchoolManagementApp.Services
{
    internal class Bootstrapper
    {
        public IUserControlFactory Run(Frame frame)
        {
            using (var scope = BuildApplication(frame).BeginLifetimeScope())
            {
                var UserControlFactory = scope.Resolve<IUserControlFactory>();
                return UserControlFactory;
            }
        }

        private static IContainer BuildApplication(Frame frame)
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

            builder.RegisterType<LoggedUser>().AsSelf().SingleInstance();

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
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<CourseClassService>().As<ICourseClassService>();
            builder.RegisterType<AbsencesService>().As<IAbsencesService>();
            builder.RegisterType<CourseClassTeacherService>().As<ICourseClassTeacherService>();

            builder.RegisterType<AuthorizationService>().AsSelf();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ClassRepository>().As<IClassRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<GradeRepository>().As<IGradeRepository>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<SpecializationCourseRepository>().As<ISpecializationCourseRepository>();
            builder.RegisterType<SpecializationRepository>().As<ISpecializationRepository>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            builder.RegisterType<CourseClassRepository>().As<ICourseClassRepository>();
            builder.RegisterType<AbsencesRepository>().As<IAbsencesRepository>();
            builder.RegisterType<CourseClassTeacherRepository>().As<ICourseClassTeacherRepository>();
        }

        private static void RegisterMainUsersPage(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherUserControlVM>().AsSelf();
            builder.RegisterType<StudentUserControlVM>().AsSelf();
            builder.RegisterType<LoginWindowVM>().AsSelf();
            builder.RegisterType<ClassMasterUserControlVM>().AsSelf();
        }

        private static void RegisterAdminControls(ContainerBuilder builder)
        {
            builder.RegisterType<ManageSpecializationCourseVM>().AsSelf();
            builder.RegisterType<ManagePersonsVM>().AsSelf();
            builder.RegisterType<ManageCoursesVM>().AsSelf();
            builder.RegisterType<ManageClassesVM>().AsSelf();

            builder.RegisterType<ManageUsersVM>().AsSelf();

            builder.RegisterType<ManageStudentsVM>().AsSelf();
            builder.RegisterType<ManageTeachersVM>().AsSelf();
            builder.RegisterType<ManageCourseClassesVM>().AsSelf();

            builder.RegisterType<ManageGradesVM>().AsSelf();
            builder.RegisterType<ManageAbsencesVM>().AsSelf();
            builder.RegisterType<ManageTeachingClassesVM>().AsSelf();

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
            builder.RegisterType<ManageTeachersAdminControl>().AsSelf();
            builder.RegisterType<ManageCourseClassesAdminControl>().AsSelf();
            builder.RegisterType<ManageGradesAdminControl>().AsSelf();
            builder.RegisterType<ManageAbsencesAdminControl>().AsSelf();
            builder.RegisterType<ManageTeachingClassesAdminControl>().AsSelf();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            //TBA
        }
    }
}
