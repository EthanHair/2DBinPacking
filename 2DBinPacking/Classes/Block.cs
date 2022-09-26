using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace _2DBinPacking.Classes
{
    public class Block
    {
        public Block(string name, double height, double width)
        {
            Name = name;
            Height = height;
            Width = width;
        }

        public string Name { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public Envelope Shape { get; set; } = new Envelope();
    }
}
