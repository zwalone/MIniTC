using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTotalCommander.Base;
using System.Security.Policy;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace MiniTotalCommander.ViewModel
{
    class TCPanelViewModel : BaseVM
    {
        #region Property
        private string _curDrive;
        public string CurDrive
        {
            get { return _curDrive; }
            set { SetProperty(ref _curDrive, value); DriveChange(); } // OnDriveChange
        }

        private string _curPath;
        public string CurPath
        {
            get { return _curPath; }
            set { SetProperty(ref _curPath, value); }//UpdateContent();
        }

        private string _selectedFile;
        public string SelectedFile
        {
            get { return _selectedFile; }
            set { SetProperty(ref _selectedFile, value); } // ChangeDirectory(Files[0]); 
        }

        private List<string> _drives;
        public List<string> Drives
        {
            get { return _drives; }
            set { SetProperty(ref _drives, value); } 
        }


        private List<string> _files;
        public List<string> Files
        {
            get { return _files; }
            set { SetProperty(ref _files, value); }
        }
        #endregion

        private ICommand _changeDirCommand = null;
        public ICommand ChangeDirCommand
        {
            get
            {
                if (_changeDirCommand == null)
                {
                    _changeDirCommand = new RelayCommand(ChangeDirectory);
                }
                return _changeDirCommand;
            }
        }

        public TCPanelViewModel()
        {
            //ChangeDirCommand = new RelayCommand(ChangeDirectory); //change go to
            Files = new List<string>();
            Drives = new List<string>();
            UpdateDrives();
            CurDrive = Drives[0];
            ChangeDirectory();
        }

        public void UpdateContent()
        {
            Files = new List<string>(); //CurPath
            //Files.Clear();
            Files.Add("...");
            Directory.GetDirectories(CurPath).ToList().ForEach(x => Files.Add($"<D> {x}"));
            Directory.GetFiles(CurPath).ToList().ForEach(x => Files.Add(x));

            for (int i = 0; i < Files.Count; i++)
            {
                string[] array = Files[i].Split('\\');
                if (Files[i].Contains("<D>")) Files[i] = $"<D> {array.Last()}";
                else Files[i] = array.Last();
            }
        }

        public void UpdateDrives()
        {
            //Drives = new List<string>();
            Drives.Clear();
            Directory.GetLogicalDrives().ToList().ForEach(x => Drives.Add(x));
        }

        public void DriveChange()
        {
            CurPath = CurDrive;
            UpdateContent();
        }

        public void ChangeDirectory()
        {
            string dir = _selectedFile;
            //string dir = "C:\\UnityProject";
            if (dir != null)
            {
                if (dir == "...")
                {
                    string[] array = CurPath.Split('\\');
                    CurPath = CurPath.Replace('\\' + array.Last(), "");
                    UpdateContent();
                }
                else if (dir.Contains("<D>"))
                {
                    dir = dir.Replace("<D> ", "");
                    if (CurPath.Length >= 4) CurPath += '\\' + dir;//+ dir
                    else CurPath += dir;
                    UpdateContent();
                }
            }
            
        }

        public void GoTo()
        {
            CurPath = "C:\\UnityProject";
            //UpdateContent();
        }
    }
}
