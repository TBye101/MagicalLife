// <copyright file="PeacefulPartyTime.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Story
{
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Util;
    using System;

    /// <summary>
    /// Used when the party could rest, or is in a peaceful area.
    /// </summary>
    public class PeacefulPartyTime
    {
        /// <summary>
        /// If unlimited is false, the player gets this many turns more in the loop, before we move on.
        /// </summary>
        private int duration;

        /// <summary>
        /// If true, the player could sit in this loop forever.
        /// </summary>
        private bool unlimited;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeacefulPartyTime"/> class.
        /// </summary>
        /// <param name="_unlimited">If true, the player could sit in this loop forever.</param>
        /// <param name="_duration">If unlimited is false, the player gets this many turns in the loop, before we move on.</param>
        public PeacefulPartyTime(bool _unlimited, int _duration)
        {
            this.unlimited = _unlimited;
            this.duration = _duration;
        }

        public void Go()
        {
            bool dontStop = true;
            if (this.unlimited)
            {
                string input;
                while (dontStop)
                {
                    Filing.Writeline("To end this peaceful cycle, type: end cycle");
                    input = Filing.ReadLine().ToLower();

                    if (input == "end cycle")
                    {
                        break;
                    }
                    else
                    {
                        foreach (ICreature item in Party.Party.TheParty)
                        {
                            if (item.YourTurn())
                            {
                                dontStop = true;
                            }
                        }
                    }
                }
            }
            else
            {
                string input;
                while (dontStop)
                {
                    this.duration--;
                    if (this.duration == 0)
                    {
                        Filing.Writeline("Cycle ended, times up!");
                        break;
                    }

                    Filing.Writeline("To end this peaceful cycle, type: end cycle");
                    input = Filing.ReadLine().ToLower();

                    if (input == "end cycle")
                    {
                        break;
                    }
                    else
                    {
                        foreach (ICreature item in Party.Party.TheParty)
                        {
                            if (item.YourTurn())
                            {
                                dontStop = true;
                            }
                        }
                    }
                }
            }
        }
    }
}