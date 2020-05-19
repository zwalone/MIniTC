using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTotalCommander.Base;
using System.IO;
using System.Windows.Input;

namespace MiniTotalCommander.ViewModel
{
    class MainWindowViewModel : BaseVM
    {
        private TCPanelViewModel _from;
        public TCPanelViewModel From
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }

        private TCPanelViewModel _to;
        public TCPanelViewModel To
        {
            get { return _to; }
            set { SetProperty(ref _to, value); }
        }

        public MainWindowViewModel()
        {
            From = new TCPanelViewModel();
            To = new TCPanelViewModel();
            CopyButtonCommand = new RelayCommand(CopyFile, CanCopyFile);
        }

        public RelayCommand CopyButtonCommand { get; set; }

        public void CopyFile()
        {
            try
            {

                if (From.SelectedFile != null)
                {
                    string fileName = Path.GetFileName(From.CurPath + "\\" + From.SelectedFile.Trim());
                    File.Copy(From.CurPath + "\\" + From.SelectedFile.Trim(), To.CurPath + "\\" + fileName);
                    To.UpdateContent();
                }
                else if (To.SelectedFile != null)
                {
                    string fileName = Path.GetFileName(To.CurPath + "\\" + To.SelectedFile.Trim());
                    File.Copy(To.CurPath + "\\" + To.SelectedFile.Trim(), From.CurPath + "\\" + fileName);
                    From.UpdateContent();
                }
                //if (!(From.CurPath + From.SelectedFile).Contains("<D>"))
                //{
                //    string fileName = Path.GetFileName(From.CurPath + "\\" + From.SelectedFile.Trim());
                //    File.Copy(From.CurPath + "\\" + From.SelectedFile.Trim(), To.CurPath + "\\" + fileName);
                //    From.UpdateContent();
                //    To.UpdateContent();
                //}
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool CanCopyFile(object param)
        {
            if (From.CurPath == To.CurPath)
            {
                return false;
            }

            if ((From.SelectedFile != null && To.Files != null && To.Files.Contains(From.SelectedFile))
                || (To.SelectedFile != null && From.Files != null && From.Files.Contains(From.SelectedFile)))
            {
                return false;
            }

            if (From.SelectedFile != null && !From.SelectedFile.Contains("<D>") && !From.SelectedFile.Contains("..."))
            {
                return true;
            }

            if (To.SelectedFile != null && !To.SelectedFile.Contains("<D>") && !To.SelectedFile.Contains("..."))
            {
                return true;
            }

            return false;
        }
    }
}
