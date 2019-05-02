using MagicalLifeAPI.Load;
using MagicalLifeAPI.Mod;
using MagicalLifeMod.Core.Load;
using System.Collections.Generic;

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

        public List<IGameLoader> Load()
        {
            return new List<IGameLoader>
            {
                new SpecificTextureLoader(),
                new SettingsInitializer(),
                new WorldGenerationRegistration(),
                new ItemRegisterer(),
                new RecipeRegisterer()
            };
        }
    }
}