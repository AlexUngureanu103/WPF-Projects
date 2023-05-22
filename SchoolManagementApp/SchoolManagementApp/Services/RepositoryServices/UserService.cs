using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class UserService : IUserService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authorizationService;

        public ObservableCollection<User> UserList { get; set; }

        public string errorMessage { get; set; }

        private readonly log4net.ILog log;

        public UserService(UnitOfWork unitOfWork, AuthorizationService authorizationService, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public ObservableCollection<User> GetAll()
        {
            var users = unitOfWork.Users.GetAll().Select(user =>
            {
                user.Person = unitOfWork.Persons.GetById(user.personId);
                return user;
            });

            return new ObservableCollection<User>(users);
        }

        public ObservableCollection<User> GetAllComplete()
        {
            var users = unitOfWork.Users.GetAll();
            foreach (User user in users)
            {
                if (user.personId != null)
                    user.Person = unitOfWork.Persons.GetById((int)user.personId);
            }

            return new ObservableCollection<User>(users);
        }

        public ObservableCollection<User> GetUsersByRole(int roleId)
        {
            var users = unitOfWork.Users.GetAll().Where(c => c.RoleId == roleId);
            foreach (User user in users)
            {
                if (user.personId != null)
                    user.Person = unitOfWork.Persons.GetById((int)user.personId);
            }

            return new ObservableCollection<User>(users);
        }

        private bool ValidateUser(User user)
        {
            if (user == null)
            {
                errorMessage = "User cannot be null";
                return false;
            }

            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                errorMessage = "Password cannot be empty";
                return false;
            }

            var hasEmailConflicts = unitOfWork.Users.Any(c => c.Email == user.Email && c.Id != user.Id);
            if (hasEmailConflicts)
            {
                errorMessage = "Email already exists";
                return false;
            }

            if (user.personId != null)
            {
                Person person = unitOfWork.Persons.GetById((int)user.personId);
                if (person == null)
                {
                    errorMessage = "Invalid personId";
                    return false;
                }
                if (UserList.Any(c => c.personId == user.personId && c.Id != user.Id))
                {
                    errorMessage = $"Person id: {user.personId} is already linked to another user";
                    return false;
                }
            }

            return true;
        }


        public void Add(User user)
        {
            if (!ValidateUser(user))
            {
                log.Error(errorMessage);
                return;
            }

            ////check password
            //user.PasswordHash = authorizationService.HashPassword(user.PasswordHash);

            //User userForDb = new User
            //{
            //    PasswordHash = user.PasswordHash,
            //    Email = user.Email,
            //    RoleId = user.RoleId,
            //    personId = user.personId
            //};
            unitOfWork.Users.Add(user);
            UserList.Add(user);
            unitOfWork.SaveChanges();
            log.Info($"User {user.Email} added");
            errorMessage = string.Empty;
        }

        public void Edit(User user)
        {
            User UserFromDb = unitOfWork.Users.GetById(user.Id);

            if (UserFromDb == null)
            {
                errorMessage = "User not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidateUser(user))
            {
                log.Error(errorMessage);
                return;
            }

            if (user.personId == null && user.Person != null)
            {
                user.personId = user.Person.Id;
            }

            //user.PasswordHash = authorizationService.HashPassword(user.PasswordHash);
            //unitOfWork.Users.Update(user);
            UserFromDb.personId = user.personId;
            UserFromDb.Email = user.Email;
            UserFromDb.PasswordHash = user.PasswordHash;
            UserFromDb.RoleId = user.RoleId;

            unitOfWork.SaveChanges();
            log.Info($"User {user.Email} edited");
            errorMessage = string.Empty;
        }

        public void Remove(User user)
        {
            if (user == null)
            {
                errorMessage = "User cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Users.Remove(user);
            UserList.Remove(user);
            unitOfWork.SaveChanges();
            log.Info($"User {user.Email} removed");
            errorMessage = string.Empty;
        }
    }
}
