using _2DBinPacking.Classes;
using NetTopologySuite.Geometries;
using System;
using System.Threading.Tasks.Sources;

namespace _2DBinPacking
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the height, width, and number of the bin(s) separated by commas");
            var input = Console.ReadLine();
            if (input is not null || String.IsNullOrEmpty(input))
            {
                string[] inputs = input.Split(",");
                if (inputs.Length == 3)
                {
                    double height = double.Parse(inputs[0]);
                    double width = double.Parse(inputs[1]);
                    int count = int.Parse(inputs[2]);

                    var bins = new List<Bin>();
                    for (int i = 0; i < count; i++)
                    {
                        bins.Add(new Bin(height, width));
                    }

                    var blocks = new List<Block>();
                    do
                    {
                        Console.WriteLine("Please enter the name, height, and width of a block separated by commas " +
                                          "or if finsihed enter 'q'");
                        input = Console.ReadLine();

                        if (input == "q") continue;

                        if (input is not null || String.IsNullOrEmpty(input))
                        {
                            inputs = input.Split(",");
                            if (inputs.Length == 3)
                            {
                                string name = inputs[0];
                                height = double.Parse(inputs[1]);
                                width = double.Parse(inputs[2]);

                                blocks.Add(new Block(name, height, width));
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                    while (input != "q");

                    // TODO: Add a new object that calculates the best layout
                    foreach(Bin bin in bins)
                    {
                        Console.WriteLine($"Bin [{bin.Height} {bin.Width}]");
                    }
                    foreach(Block block in blocks)
                    {
                        Console.WriteLine($"Block [{block.Name} {block.Height} {block.Width}]");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please rerun the program");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please rerun the program");
            }

            Coordinate[] points = new Coordinate[] { new Coordinate(), new Coordinate(1,0), new Coordinate(1,1),
                                                     new Coordinate(2,1), new Coordinate(2,2), new Coordinate(0,2),
                                                     new Coordinate()};

            var yellow = new Polygon(new LinearRing(points));

            Coordinate[] points1 = new Coordinate[] { new Coordinate(1,0), new Coordinate(1,1), new Coordinate(2,1),
                                                     new Coordinate(2,0), new Coordinate(1,0)};

            var green = new Polygon(new LinearRing(points1));

            Coordinate[] points2 = new Coordinate[] { new Coordinate(1,1), new Coordinate(2,1), new Coordinate(2,0),
                                                     new Coordinate(3,0), new Coordinate(3,2), new Coordinate(1,2),
                                                     new Coordinate(1,1)};

            var red = new Polygon(new LinearRing(points2));

            Console.WriteLine("Yellow overlaps Green (Should be false): " + yellow.Overlaps(green));
            Console.WriteLine("Yellow overlaps Red (Should be true): " + yellow.Overlaps(red));
            Console.WriteLine("Red overlaps Green (Should be false): " + red.Overlaps(green));
            Console.WriteLine("Red overlaps Yellow (Should be true): " + red.Overlaps(yellow));
            Console.WriteLine("Green overlaps Yellow (Should be false): " + green.Overlaps(yellow));
            Console.WriteLine("Green overlaps Red (Should be false): " + green.Overlaps(red));
        }
    }
}