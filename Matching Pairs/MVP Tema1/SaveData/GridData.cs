using System.Collections.Generic;

namespace MVP_Tema1.SaveData
{
    public class GridData
    {
        public int count { get; set; }

        public int level { get; set; }

        public int rows { get; set; }

        public int columns { get; set; }

        public List<int> ImagesRow { get; set; }

        public List<int> ImagesColumn { get; set; }

        public List<string> ImagesPath { get; set; }
    }
}