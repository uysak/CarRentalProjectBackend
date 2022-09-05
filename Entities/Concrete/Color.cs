﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        public Color(int colorId, string colorName)
        {
            this.colorId = colorId;
            this.colorName = colorName;
        }

        public int colorId { get; set; }
        public string colorName { get; set; }
    }
}