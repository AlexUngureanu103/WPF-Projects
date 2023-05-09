using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices;
using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    internal class ManagePersonsVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly PersonService personService;

        private readonly UnitOfWork unitOfWork;

        public ManagePersonsVM(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            unitOfWork = new UnitOfWork(dbContext);
            personService = new PersonService(unitOfWork);

            PersonList = personService.GetAll();
        }

        public ObservableCollection<Person> PersonList
        {
            get => personService.PersonList;
            set => personService.PersonList = value;
        }
    }
}
