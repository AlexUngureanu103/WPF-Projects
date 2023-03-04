using System;

namespace MVP_Tema1.Authentification
{
    internal class Account
    {
        public string Username { get; private set; }

        //public string Password { get; private set; }

        public string AvatarPath { get; private set; }

        public Account(string username, /*string password, */string avatarPath)
        {
            if (username == string.Empty)
            {
                throw new ArgumentException("Username cannot be empty!", nameof(username));
            }
            //if (password == string.Empty)
            //{
            //    throw new ArgumentException("Password cannot be empty!", nameof(password));
            //}
            //Password = password;
            if (avatarPath == string.Empty)
            {
                throw new ArgumentException("Avatar path cannot be empty!", nameof(avatarPath));
            }

            Username = username;
            AvatarPath = avatarPath;
        }
    }
}
