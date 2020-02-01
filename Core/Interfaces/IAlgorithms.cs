using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAlgorithms
    {
        bool FirstFit();
        bool BestFit();
        bool WorstFit();
        bool NextFit();
    }
}
