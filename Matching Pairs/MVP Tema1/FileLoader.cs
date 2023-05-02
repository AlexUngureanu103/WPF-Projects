using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVP_Tema1
{
    internal class FileLoader
    {
        private string folder = string.Empty;

        private string[] imagePaths;

        private string pathsFolder;

        /// <summary>
        /// Initializes a new instance of the FileLoader class with the specified folder path and paths folder name.
        /// </summary>
        /// <param name="folder">The path to the folder containing the image files to be loaded.</param>
        /// <param name="pathsFolderName">The name of the folder to store the paths to the loaded image files. Without an extension</param>
        /// <remarks>
        /// The folder parameter must not be null or empty.
        /// The pathsFolderName parameter must not be null or empty.
        /// </remarks>
        public FileLoader(string folder, string pathsFolderName)
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArgumentException("Folder cannot be null or empty", nameof(folder));
            if (string.IsNullOrEmpty(pathsFolderName))
                throw new ArgumentException("Paths folder cannot be null or empty", nameof(pathsFolder));
            this.pathsFolder = pathsFolderName + ".txt";
            if (File.Exists(pathsFolder))
            {
                File.WriteAllText(pathsFolder, string.Empty);
            }
            else File.Create(pathsFolder);
            this.folder = folder;
            LoadFiles();
        }

        private void LoadFiles()
        {
            imagePaths = Directory.GetFiles(folder, "*.jpg");
            UploadPaths(imagePaths);
            imagePaths = Directory.GetFiles(folder, "*.png");
            UploadPaths(imagePaths);
            imagePaths = Directory.GetFiles(folder, "*.jpeg");
            UploadPaths(imagePaths);
            imagePaths = Directory.GetFiles(folder, "*.gif");
            UploadPaths(imagePaths);
        }

        private void UploadPaths(string[] paths)
        {
            foreach (string path in paths)
            {
                File.AppendAllText(pathsFolder, path + '\n');
            }
        }

        public List<string> LoadPaths()
        {
            return File.ReadAllLines(pathsFolder).ToList();
        }
    }
}
