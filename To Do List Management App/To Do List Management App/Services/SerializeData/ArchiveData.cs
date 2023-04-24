using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.SerializeData
{
    public class ArchiveData
    {
        private readonly StartUpPageVM startUpPageVM;

        private string dirName;

        private string FullDirName;

        public ObservableCollection<string> Databases { get; private set; }

        private string Database;

        public ArchiveData(StartUpPageVM startUpPageVM, string dirName)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            this.dirName = dirName;
            Database = "";
            FullDirName = dirName + "/" + Database;
            DeserializeDatabasesPath();
        }

        public void DeleteDataBase(string database)
        {
            if (Databases.Contains(database))
            {
                if (Directory.Exists(FullDirName))
                {
                    Directory.Delete(dirName + "/" + database, true);
                }
                Databases.Remove(database);
                SerializeDatabasesPath();
            }
        }

        public void AddNewDataBase(string database)
        {
            if (!Databases.Contains(database))
            {
                Databases.Add(database);
                Database = database;
                FullDirName = dirName + "/" + Database;
                startUpPageVM.RootToDoList.Clear();
                startUpPageVM.AvailableCategories.Clear();
                this.ArchiveSavedData(database);
                startUpPageVM.startUpPageCommands.LoadArchivedData();
            }
        }

        private void DeserializeDatabasesPath()
        {
            if (!File.Exists(dirName + "/Databases.xml"))
            {
                Databases = new ObservableCollection<string>();
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<string>));

            using (StreamReader reader = new StreamReader(dirName + "/Databases.xml"))
            {
                ObservableCollection<string> categories = (ObservableCollection<string>)serializer.Deserialize(reader);
                Databases = categories;
                Database = Databases.Last();
                FullDirName = dirName + "/" + Database;
            }
        }

        private void SerializeDatabasesPath()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<string>));
            using (StreamWriter writer = new StreamWriter(dirName + "/Databases.xml", false))
            {
                serializer.Serialize(writer, Databases);
            }
        }

        public CurrentStructure LoadLastArchive()
        {
            return LoadArchive(Database);
        }
        /// <summary>
        /// Deserializes the directories structure and then creates an application structure which can be used in the UI
        /// </summary>
        /// <returns>The Application structure</returns>
        public CurrentStructure LoadArchive(string database = "db")
        {
            Database = database;
            FullDirName = dirName + "/" + database;
            CurrentStructure structure = new CurrentStructure();

            ObservableCollection<ToDoList> TDL = new ObservableCollection<ToDoList>();
            ObservableCollection<string> categories = DeserializeCategories(FullDirName);
            foreach (string subDir in Directory.GetDirectories(FullDirName))
            {
                TDL.Add(DeserializeToDoList(subDir));
            }
            structure.TDL = TDL;
            structure.StatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPanel(TDL);
            structure.Categories = categories;
            return structure;
        }

        private ToDoList DeserializeToDoList(string directory)
        {
            // Deserialize the ToDoList from the XML file
            XmlSerializer serializer = new XmlSerializer(typeof(ToDoList));
            using (FileStream stream = new FileStream($"{directory}/{directory.Split('\\').Last()}.xml", FileMode.Open))
            {
                ToDoList toDoList = (ToDoList)serializer.Deserialize(stream);

                // Deserialize sub-ToDoLists recursively
                foreach (string subDir in Directory.GetDirectories(directory))
                {
                    ToDoList subToDoList = DeserializeToDoList(subDir);
                    toDoList.toDoLists.Add(subToDoList);
                }

                return toDoList;
            }
        }

        /// <summary>
        /// Using the given structure of the data, create a tree like directories , where each folder is the name of the TDL . 
        /// Each of those can contain multiple folders of TDL , and an xml file file containing the current TDL informations
        /// </summary>
        public void ArchiveSavedData(string database = "db")
        {
            //Database = database;
            //FullDirName = dirName + "/" + Database;
            if (Directory.Exists(FullDirName))
            {
                Directory.Delete(FullDirName, true);
            }
            Directory.CreateDirectory(FullDirName);

            foreach (var TDL in startUpPageVM.RootToDoList)
            {
                SerializeToDoList(TDL, FullDirName);
            }
            SerializeCategories(startUpPageVM.AvailableCategories, FullDirName);
            if (!Databases.Contains(database))
            {
                Databases.Add(database);
            }
            else
            {
                Databases.Move(Databases.IndexOf(database), Databases.Count - 1);
            }
            SerializeDatabasesPath();
        }

        private ObservableCollection<string> DeserializeCategories(string parentDir = "Archive")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<string>));

            using (StreamReader reader = new StreamReader(parentDir + "/categories.xml"))
            {
                ObservableCollection<string> categories = (ObservableCollection<string>)serializer.Deserialize(reader);
                return categories;
            }
        }

        private void SerializeCategories(ObservableCollection<string> categories, string parentDir = "Archive")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<string>));
            using (StreamWriter writer = new StreamWriter(parentDir + "/categories.xml", false))
            {
                serializer.Serialize(writer, categories);
            }
        }

        private void SerializeToDoList(ToDoList toDoList, string parentDir = "Archive")
        {
            // Create a directory for the ToDoList
            string dirPath = Path.Combine(parentDir, toDoList.Name);
            Directory.CreateDirectory(dirPath);

            // Serialize the ToDoList to an XML file
            XmlSerializer serializer = new XmlSerializer(typeof(ToDoList));
            using (FileStream stream = new FileStream($"{dirPath}/{toDoList.Name}.xml", FileMode.Create))
            {
                serializer.Serialize(stream, toDoList);
            }

            // Serialize sub-ToDoLists recursively
            foreach (ToDoList subToDoList in toDoList.toDoLists)
            {
                SerializeToDoList(subToDoList, dirPath);
            }
        }
    }
}
