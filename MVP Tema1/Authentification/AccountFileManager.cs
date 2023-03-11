using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVP_Tema1.Authentification
{
    internal class AccountFileManager
    {
        private string FilePath;

        private List<Account> Accounts;

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
            this.FilePath = Path.Combine(folderPath, "Accounts.txt");
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
            ReadAccounts();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
            File.WriteAllLines(FilePath, ParseAccountList(Accounts));
        }

        public void RemoveAccount(Account account)
        {
            Accounts.Remove(account);
            File.WriteAllLines(FilePath, ParseAccountList(Accounts));
        }

        public void UpdateAccount(Account account)
        {
            int index = Accounts.FindIndex(a => a.Username == account.Username);
            Accounts[index] = account;
            File.WriteAllLines(FilePath, ParseAccountList(Accounts));
        }

        public List<string> GetRegisteredAccounts()
        {
            {
                List<string> usernames = new List<string>();
                foreach (Account account in Accounts)
                {
                    usernames.Add(account.Username);
                }
                return usernames;
            }
        }

        public Account GetAccount(string username)
        {
            return Accounts.Find(a => a.Username == username);
        }

        private void ReadAccounts()
        {
            Accounts = ParseFileList(File.ReadAllLines(FilePath).ToList());
        }

        private List<Account> ParseFileList(List<string> fileLines)
        {
            List<Account> accounts = new List<Account>();
            foreach (string line in fileLines)
            {
                string[] accountData = line.Split('/');
                Account account = new Account(accountData[0], accountData[1], int.Parse(accountData[2]), int.Parse(accountData[3]));
                accounts.Add(account);
            }
            return accounts;
        }

        private List<string> ParseAccountList(List<Account> accounts)
        {
            List<string> fileLines = new List<string>();
            foreach (Account account in accounts)
            {
                string line = $"{account.Username}/{account.AvatarPath}/{account.Wins}/{account.GamesPlayed}";
                fileLines.Add(line);
            }
            return fileLines;
        }
    }
}
