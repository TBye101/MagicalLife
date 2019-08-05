using System.Collections.Generic;
using MLAPI.Load;
using MLAPI.Mod;
using MLCoreMod.Core.Load;

namespace MLCoreMod.Core
{
    /// <summary>
    /// The entry point of the vanilla game mod.
    /// </summary>
    public class MlModMain : IMod
    {
        private readonly ModInformation Info = new ModInformation(DescriptionValues.ModId, DescriptionValues.DisplayName,
            DescriptionValues.AuthorName, DescriptionValues.Description, DescriptionValues.Version);

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