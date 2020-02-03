using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Process
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string AlgorithmType { get; set; }
        public Block Block { get; set; }

    }
}
