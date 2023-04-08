using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace To_Do_List_Management_App.Services.SerializeData
{
    public class ManageDataUsage
    {
        private string filePath;

        public ManageDataUsage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            this.filePath = filePath + ".xml";
        }

        public void SaveData(CurrentStructure currentStructure)
        {
            if (currentStructure == null)
            {
                throw new ArgumentNullException(nameof(currentStructure));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CurrentStructure), new XmlRootAttribute("Data"));

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, currentStructure);
            }
        }

        public CurrentStructure LoadData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CurrentStructure), new XmlRootAttribute("Data"));
            if (!File.Exists(filePath))
            {
                return new CurrentStructure();
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                CurrentStructure currentStructure = (CurrentStructure)serializer.Deserialize(reader);
                return currentStructure;
            }
        }
    }
}
