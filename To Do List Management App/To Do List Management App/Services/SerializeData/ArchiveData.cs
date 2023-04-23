using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.SerializeData
{
    internal class ArchiveData
    {
        private readonly StartUpPageVM startUpPageVM;

        private string dirName;

        public ArchiveData(StartUpPageVM startUpPageVM, string dirName)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            this.dirName = dirName;
        }

        /// <summary>
        /// Deserializes the directories structure and then creates an application structure which can be used in the UI
        /// </summary>
        /// <returns>The Application structure</returns>
        public CurrentStructure LoadArchive()
        {
            CurrentStructure structure = new CurrentStructure();

            ObservableCollection<ToDoList> TDL = new ObservableCollection<ToDoList>();
            ObservableCollection<string> categories = DeserializeCategories();
            foreach (string subDir in Directory.GetDirectories(dirName))
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
        public void ArchiveSavedData()
        {
            if (Directory.Exists(dirName))
            {
                Directory.Delete(dirName, true);
            }

            foreach (var TDL in startUpPageVM.RootToDoList)
            {
                SerializeToDoList(TDL);
            }
            SerializeCategories(startUpPageVM.AvailableCategories);
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
