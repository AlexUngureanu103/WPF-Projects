using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace To_Do_List_Management_App.ResourceManagement
{
    public class LoadImages
    {
        private string folderPath;

        public List<string> ImagePaths { get; }

        public LoadImages(string folderPath)
        {
            this.folderPath = folderPath ?? throw new ArgumentNullException(nameof(folderPath));
            ImagePaths = new List<string>();
            LoadFileType("jpg");
            LoadFileType("png");
            LoadFileType("gif");
            LoadFileType("jpeg");
        }

        private void LoadFileType(string extensionType)
        {
            ImagePaths.AddRange(Directory.GetFiles(folderPath, $"*.{extensionType}").ToList());
        }
    }
}
