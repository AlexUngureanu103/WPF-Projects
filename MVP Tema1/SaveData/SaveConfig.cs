using MVP_Tema1.Authentification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace MVP_Tema1.SaveData
{
    public class SaveConfig
    {
        private string FilePath;

        public SaveConfig(string folderPath, Account account)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("Folder cannot be null or empty", nameof(folderPath));
            }
            if (account == null)
            {
                throw new ArgumentException("Account cannot be null", nameof(account));
            }
            this.FilePath = Path.Combine(folderPath, account.Username);
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
        }

        public void SaveDataToFile(Grid boardConfiguration, int level)
        {

            if (boardConfiguration == null)
            {
                throw new ArgumentException("Board configuration cannot be null", nameof(boardConfiguration));
            }
            if (level < 0)
            {
                throw new ArgumentException("Level cannot be negative", nameof(level));
            }

            GridData gridData = new GridData()
            {
                rows = boardConfiguration.RowDefinitions.Count,
                columns = boardConfiguration.ColumnDefinitions.Count,
                level = level,
                ImagesColumn = new List<int>(),
                ImagesRow = new List<int>(),
                ImagesPath = new List<string>()
            };
            foreach (var item in boardConfiguration.Children)
            {
                if (item is Image)
                {
                    Image img = (Image)item;
                    Tuple<int, int, string> imageData;
                    int row = Grid.GetRow(img);
                    int column = Grid.GetColumn(img);
                    string path = img.Source.ToString();

                    gridData.ImagesRow.Add(row);
                    gridData.ImagesColumn.Add(column);
                    gridData.ImagesPath.Add(path);

                }
            }
            string auxFilePath = Path.Combine(FilePath, DateTime.Now.ToString().GetHashCode() + ".xml");
            Thread.Sleep(10);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GridData));
            using (StreamWriter writer = new StreamWriter(auxFilePath))
            {
                xmlSerializer.Serialize(writer, gridData);
            }
        }

        public List<string> GetSavedGames()
        {
            return Directory.GetFiles(FilePath, "*.xml").ToList();
        }

        public GridData LoadDataFromFile(string filePath)
        {
            GridData gridData = new GridData();

            return gridData;
        }
    }
}
