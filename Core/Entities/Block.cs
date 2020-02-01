using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public partial class Block
    {

        public Block()
        {
            Processes = new HashSet<Process>();
        }

        public int Id { get; set; }
        public long Size { get; set; }

        public ICollection<Process> Processes { get; set; }
    }
}
