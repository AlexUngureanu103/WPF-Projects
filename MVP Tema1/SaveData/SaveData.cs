using System;
using System.IO;

namespace MVP_Tema1.SaveData
{
    public  class Data
    {
        private string FilePath;


        public Data(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("Folder cannot be null or empty", nameof(folderPath));
            }
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            this.FilePath = Path.Combine(folderPath, "Data.txt");
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }
    }
}
