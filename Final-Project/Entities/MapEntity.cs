﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Entites
{
    public class MapEntity
    {
        public PointF position;
        public Size size;

        public MapEntity(PointF pos, Size size)
        {
            this.position = pos;
            this.size = size;
        }
    }
}
