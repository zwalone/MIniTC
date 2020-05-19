using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTotalCommander.Base;
using System.IO;

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
        }

        public void CopyFile(string fromPath, string toPath)
        {
            try
            {
                File.Copy(fromPath, toPath);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
