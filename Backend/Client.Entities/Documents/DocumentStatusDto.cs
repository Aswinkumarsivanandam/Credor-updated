﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Credor.Client.Entities
{
    public class DocumentStatusDto
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}