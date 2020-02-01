using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BlockDTO
    {
        public long Size { get; set; }
        public int Order { get; set; }

        public ICollection<ProcessDTO> Processes { get; set; }
    }
}
