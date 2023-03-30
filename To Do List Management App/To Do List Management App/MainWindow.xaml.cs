﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using To_Do_List_Management_App.ResourceManagement;

namespace To_Do_List_Management_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoadImages loadImages;

        public MainWindow()
        {
            loadImages = new LoadImages(@"Images\CategoriesFolderIcons");
            InitializeComponent();
        }
    }
}