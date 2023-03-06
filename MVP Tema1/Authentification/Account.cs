using System;

namespace MVP_Tema1.Authentification
{
    public class Account
    {
        public string Username { get; private set; }


        public string AvatarPath { get; set; }

        public int Wins { get; set; }

        public Account(string username, string avatarPath, int wins)
        {
            if (username == string.Empty)
            {
                throw new ArgumentException("Username cannot be empty!", nameof(username));
            }
            if (avatarPath == string.Empty)
            {
                throw new ArgumentException("Avatar path cannot be empty!", nameof(avatarPath));
            }
            if (wins < 0)
            {
                wins = 0;
            }
            this.Wins = wins;

            Username = username;
            AvatarPath = avatarPath;
        }
    }
}
