using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAlgorithms
    {
        int AddProcessToBlock(long processSize, List<BlockDTO> blocks);
    }
}
