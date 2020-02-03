using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ProcessDTO
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string AlgorithmType { get; set; }
        public BlockDTO Block { get; set; }
    }
}
