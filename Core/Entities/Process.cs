﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Process
    {
        public int Id { get; set; }
        public int IdBlock { get; set; }
        public long Size { get; set; }
        public Block Block { get; set; }

    }
}