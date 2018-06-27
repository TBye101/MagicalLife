using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell.StackTest
{
    public abstract class Base
    {
        public Point Location { get; set; }

        public Base(Point point)
        {
            this.Location = point;
        }
    }
}
