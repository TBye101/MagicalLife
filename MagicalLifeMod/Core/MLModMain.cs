using MagicalLifeAPI.Mod;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core
{
    /// <summary>
    /// The entry point of the vanilla game mod.
    /// </summary>
    public class MLModMain : IMod
    {
        private readonly ModInformation Info = new ModInformation(DescriptionValues.ModID, DescriptionValues.DisplayName,
            DescriptionValues.AuthorName, DescriptionValues.Description, DescriptionValues.Version);

        public MLModMain()
        {

        }

        public ModInformation GetInfo()
        {
            return this.Info;
        }

        public void Load()
        {
        }
    }
}
