using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E
{
    /// <summary>
    /// All consumers of <see cref="ITimeDependent"/> recieve calls to the methods defined in order to provide uniformed time management.
    /// </summary>
    public interface ITimeDependent
    {
        /// <summary>
        /// Called at the beginnning of a round.
        /// </summary>
        void RoundStart();

        /// <summary>
        /// Called at the end of a round.
        /// </summary>
        void RoundEnd();

        /// <summary>
        /// Called at the start of a turn.
        /// </summary>
        void TurnStart();

        /// <summary>
        /// Called at the end of a turn.
        /// </summary>
        void TurnEnd();
    }
}
