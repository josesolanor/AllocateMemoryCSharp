using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Core
{
    public class Repository : IRepository
    {
        public Task<bool> AddProcessByAlgorithm(ProcessDTO processData, string algorithmType)
        {
            throw new NotImplementedException();
        }

        public Task<BlockDTO> GetAllMemoryBlocks()
        {
            throw new NotImplementedException();
        }
    }
}
