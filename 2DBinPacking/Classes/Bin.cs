using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking.Classes
{
    public class Bin
    {
        public Bin(double height, double width)
        {
            Height = height;
            Width = width;
            Shape = new Envelope(new Coordinate(), new Coordinate(width, height));
        }

        public double Height { get; set; }

        public double Width { get; set; }

        public Envelope Shape { get; }

        public List<Block> Blocks { get; set; } = new List<Block>();

        public bool TryAddBlock(Block newBlock)
        {
            var canAdd = true;
            foreach (Block block in Blocks)
            {
                if (block.Shape.Intersects(newBlock.Shape))
                {
                    canAdd = false;
                    break;
                }
            }
            return canAdd;
        }
    }
}
