namespace MVP_Tema1.Authentication
{
    internal interface IAuthenticationService
    {
        bool IsUserAuthenticated { get; }

        void Login(string password);

        void Logout();
    }
}
