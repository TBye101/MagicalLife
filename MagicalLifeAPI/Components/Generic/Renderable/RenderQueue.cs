﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// A queue used to determine in what order things should be rendered.
    /// </summary>
    public class RenderQueue
    {
        /// <summary>
        /// The visuals in this render queue.
        /// </summary>
        public SortedSet<AbstractVisual> Visuals { get; set; }

        public RenderQueue()
        {
            this.Visuals = new SortedSet<AbstractVisual>(new RenderQueueComparer());
        }
    }
}
