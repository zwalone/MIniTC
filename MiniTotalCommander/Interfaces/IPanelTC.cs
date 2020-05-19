using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTotalCommander.Interfaces
{
    public interface IPanelTC
    {
        string CurrentPath { get; }
        string[] Drives { get; }
        string[] CurrentPathContent { get; }
    }
}
