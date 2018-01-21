using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// A 3 dimensional point class.
    /// </summary>
    public class Point3D : Object
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D(string str)
        {
            string[] delimiter = new string[] { ", " };
            string[] numbers = str.Split(delimiter, 3, StringSplitOptions.RemoveEmptyEntries);

            int x;
            int y;
            int z;

            int.TryParse(numbers[0], out x);
            int.TryParse(numbers[1], out y);
            int.TryParse(numbers[2], out z);

            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return this.X.ToString() + ", " + this.Y.ToString() + ", " + this.Z.ToString();
        }
    }
}
