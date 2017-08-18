namespace EarthWithMagicAPI.API.Interfaces.Items
{
    public abstract class IAmulet : IItem
    {
        public IAmulet(string name, double weight, string imagePath, string documentationPath) : base(name, weight, imagePath, documentationPath)
        {
        }
    }
}