using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVP_Tema1.Authentification
{
    internal class AccountFileManager
    {
        private string filePath;

        private List<string> accounts;

        public AccountFileManager(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("Folder cannot be null or empty", nameof(folderPath));
            }
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            this.filePath = Path.Combine(folderPath, "Accounts.txt");
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                File.WriteAllText(filePath, string.Empty);
            }
            ReadAccounts();
        }

        public void AddAccount(string account)
        {
            accounts.Add(account);
            File.WriteAllLines(filePath, accounts);
        }

        public void RemoveAccount(string account)
        {
            accounts.Remove(account);
            File.WriteAllLines(filePath, accounts);
        }

        private void ReadAccounts()
        {
            accounts = File.ReadAllLines(filePath).ToList();
        }
    }
}
