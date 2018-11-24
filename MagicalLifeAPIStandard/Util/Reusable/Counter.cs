using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Util.Reusable
{
    /// <summary>
    /// Used to count things.
    /// </summary>
    public class Counter
    {
        private int Count;

        public int Increment()
        {
            this.Count++;
            return this.Count;
        }

        public int Deincrement()
        {
            this.Count--;
            return this.Count;
        }

        public void Reset()
        {
            this.Count = 0;
        }
    }
}