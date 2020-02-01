﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository
    {
        Task<BlockDTO> GetAllMemoryBlocks();
        Task<bool> AddProcessByAlgorithm(ProcessDTO processData, string algorithmType);
    }
}
