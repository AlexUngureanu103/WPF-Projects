using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using System;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class UserService/* : ICollectionService<User>*/
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public User Add(User user)
        {
            if (user == null) return null;

            var hasEmailConflicts = unitOfWork.Users.Any(c => c.Email == user.Email);
            if (hasEmailConflicts) return null;

            unitOfWork.Users.Add(user);
            unitOfWork.SaveChanges();
            return user;
        }

        public bool Edit(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.PasswordHash))
            {
                return false;
            }

            User User = unitOfWork.Users.GetById(user.Id);

            if (user == null) return false;

            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
            return true;
        }

        public User Remove(User user)
        {
            if (user == null) return null;

            unitOfWork.Users.Remove(user);
            unitOfWork.SaveChanges();
            return user;
        }
    }
}
