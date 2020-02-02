using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Core
{
    public class FirstFit : IAlgorithms
    {
        public int AddProcessToBlock(long processSize, List<BlockDTO> blocks)
        {
            foreach (var block in blocks)
            {
                if (processSize <= block.UpdatedSize)
                {
                    return block.Order;
                }
            }
            return 0;
        }
    }

    public class BestFit : IAlgorithms
    {
        public int AddProcessToBlock(long processSize, List<BlockDTO> blocks)
        {
            var difference = blocks[0].UpdatedSize - processSize;
            var order = 0;

            foreach (var block in blocks)
            {
                if (block.UpdatedSize - processSize <= difference)
                {
                    difference = block.UpdatedSize - processSize;
                    order = block.Order;                    
                }
            }
            return order;
        }
    }

    public class WorstFit : IAlgorithms
    {
        public int AddProcessToBlock(long processSize, List<BlockDTO> blocks)
        {
            throw new NotImplementedException();
        }
    }

    public class NextFit : IAlgorithms
    {
        public int AddProcessToBlock(long processSize, List<BlockDTO> blocks)
        {
            throw new NotImplementedException();
        }
    }



}
