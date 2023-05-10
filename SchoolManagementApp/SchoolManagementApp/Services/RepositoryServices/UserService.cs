using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
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

        private string errorMessage;

        public UserService(UnitOfWork unitOfWork, AuthorizationService authorizationService)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        }

        public ObservableCollection<User> GetAll()
        {
            var users = unitOfWork.Users.GetAll();
            foreach (User user in users)
            {
                if (user.personId != null)
                    user.Person = unitOfWork.Persons.GetById((int)user.personId);
                user.PasswordHash = string.Empty;
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
                if (UserList.Any(c => c.personId == user.personId && c.personId != user.personId))
                {
                    errorMessage = "Person is already linked to another user";
                    return false;
                }
            }

            return true;
        }


        public void Add(User user)
        {
            if (!ValidateUser(user)) return;

            //check password
            user.PasswordHash = authorizationService.HashPassword(user.PasswordHash);

            unitOfWork.Users.Add(user);
            UserList.Add(user);
            unitOfWork.SaveChanges();
            user.PasswordHash = string.Empty;
        }

        public void Edit(User user)
        {
            User User = unitOfWork.Users.GetById(user.Id);

            if (User == null)
            {
                errorMessage = "User not found";
                return;
            }

            if (!ValidateUser(user)) return;

            if (user.personId == null && user.Person != null)
            {
                user.personId = user.Person.Id;
            }

            user.PasswordHash = authorizationService.HashPassword(user.PasswordHash);
            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
            user.PasswordHash = string.Empty;
        }

        public void Remove(User user)
        {
            if (user == null)
            {
                errorMessage = "User cannot be null";
                return;
            }

            unitOfWork.Users.Remove(user);
            UserList.Remove(user);
            unitOfWork.SaveChanges();
        }
    }
}
