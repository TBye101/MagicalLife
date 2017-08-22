using EarthWithMagicAPI.API.Creature;
namespace EarthWithMagicAPI.API.Story
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used when the party could rest, or is in a peaceful area.
    /// </summary>
    public class PeacefulPartyTime
    {
        /// <summary>
        /// If true, the player could sit in this loop forever.
        /// </summary>
        private bool _unlimited;

        /// <summary>
        /// If unlimited is false, the player gets this many turns more in the loop, before we move on.
        /// </summary>
        private int _duration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeacefulPartyTime"/> class.
        /// </summary>
        /// <param name="unlimited">If true, the player could sit in this loop forever.</param>
        /// <param name="duration">If unlimited is false, the player gets this many turns in the loop, before we move on.</param>
        public PeacefulPartyTime(bool unlimited, int duration)
        {
            this._unlimited = unlimited;
            this._duration = duration;
        }

        public void Go()
        {
            if (this._unlimited)
            {
                string input;
                while (true)
                {
                    Util.Util.WriteLine("To end this peaceful cycle, type: end cycle");
                    input = Console.ReadLine().ToLower();

                    if (input == "end cycle")
                    {
                        break;
                    }
                    else
                    {
                        foreach (ICreature item in Party.Party.TheParty)
                        {
                            item.YourTurn(null);
                        }
                    }
                }
            }
            else
            {
                string input;
                while (true)
                {
                    this._duration--;
                    if (this._duration == 0)
                    {
                        Util.Util.WriteLine("Cycle ended, times up!");
                        break;
                    }

                    Util.Util.WriteLine("To end this peaceful cycle, type: end cycle");
                    input = Console.ReadLine().ToLower();

                    if (input == "end cycle")
                    {
                        break;
                    }
                    else
                    {
                        foreach (ICreature item in Party.Party.TheParty)
                        {
                            item.YourTurn(null);
                        }
                    }
                }
            }
        }
    }
}
