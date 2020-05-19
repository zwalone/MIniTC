using System;
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
using MiniTotalCommander.Interfaces;
using System.Collections.ObjectModel;
using MiniTotalCommander.Base;

namespace MiniTotalCommander.View
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        //OpenDirCommand
        public static readonly DependencyProperty OpenDirectoryCommandProperty =
            DependencyProperty.Register("OpenDirCommand", typeof(ICommand),
                typeof(PanelTC), new PropertyMetadata(null));

        public ICommand OpenDirCommand
        {
            get { return (ICommand)GetValue(OpenDirectoryCommandProperty); }
            set { SetValue(OpenDirectoryCommandProperty, value); }
        }

        //CurrentPath
        public static readonly DependencyProperty CurrentPathProperty =
            DependencyProperty.Register("CurrentPath", typeof(string),
                typeof(PanelTC), new PropertyMetadata(""));

        public string CurrentPath
        {
            get { return (string)GetValue(CurrentPathProperty); }
            set { SetValue(CurrentPathProperty, value); }
        }

        //CurrentDrive
        public static readonly DependencyProperty SelectedDriveProperty =
            DependencyProperty.Register("SelectedDrive", typeof(string), 
                typeof(PanelTC), new PropertyMetadata(""));

        public string SelectedDrive
        {
            get { return (string)GetValue(SelectedDriveProperty); }
            set { SetValue(SelectedDriveProperty, value); }
        }


        //SelectedFile
        public static readonly DependencyProperty SelectedFileProperty =
            DependencyProperty.Register("SelectedFile", typeof(string),
                typeof(PanelTC), new PropertyMetadata(""));

        public string SelectedFile
        {
            get { return (string)GetValue(SelectedFileProperty); }
            set { SetValue(SelectedFileProperty, value); }
        }


        //Drives
        public static readonly DependencyProperty DrivesProperty =
            DependencyProperty.Register("Drives", typeof(List<string>),
                typeof(PanelTC), new PropertyMetadata(null));

        public List<string> Drives
        {
            get { return (List<string>)GetValue(DrivesProperty); }
            set { SetValue(DrivesProperty, value); }
        }

        //Files
        public static readonly DependencyProperty FilesProperty =
            DependencyProperty.Register("Files", typeof(List<string>),
                typeof(PanelTC),new PropertyMetadata(null));

        public List<string> Files
        {
            get { return (List<string>)GetValue(FilesProperty); }
            set { SetValue(FilesProperty, value); }
        }

    }
}
