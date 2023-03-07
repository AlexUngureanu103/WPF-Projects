using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVP_Tema1.SaveData
{
    public class GridData
    {
        public int level { get; set; }

        public int rows { get; set; }

        public int columns { get; set; }

        public List<int> ImagesRow { get; set; }

        public List<int> ImagesColumn { get; set; }

        public List<string> ImagesPath { get; set; }

    }
}