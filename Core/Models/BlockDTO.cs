using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BlockDTO
    {
        public int Id { get; set; }
        public long Size { get; set; }
        public long UpdatedSize
        {
            get
            {
                long ProcessTotalSize = 0;
                foreach (var Process in Processes)
                {
                    ProcessTotalSize += Process.Size;
                }
                long UpdatedSizeTotal = Size - ProcessTotalSize;
                return UpdatedSizeTotal;
            }
        }
        public int Order { get; set; }

        public ICollection<ProcessDTO> Processes { get; set; }
    }
}
