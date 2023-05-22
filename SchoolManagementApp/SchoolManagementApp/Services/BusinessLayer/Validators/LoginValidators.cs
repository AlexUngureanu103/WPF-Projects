namespace SchoolManagementApp.Services.Validators
{
    internal static class LoginValidators
    {
        public static bool CanLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;

            return true;
        }
    }
}
