﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Color : IEntity
    {

        public short colorId { get; set; }
        public string colorName { get; set; }
    }
}
