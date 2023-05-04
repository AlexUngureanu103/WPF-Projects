using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.Services.Validators
{
    internal static class UsersValidators
    {
        public static bool ValidateNewUser(string userEmail, string userPassword, Role role)
        {
            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(userPassword) || role == null)
            {
                return false;
            }
            if (userEmail.Contains("@") && userEmail.Contains("."))
            {
                return true;
            }
            else { return false; }
            return true;
        }
    }
}
