namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// The interface for a gem.
    /// </summary>
    public abstract class IGem : IItem
    {
        public IGem(string name, double weight, string imagePath, string documentationPath) : base(name, weight, imagePath, documentationPath)
        {
        }
    }
}