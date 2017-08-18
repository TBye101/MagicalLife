namespace EarthWithMagicAPI.API.Interfaces.Items
{
    public abstract class IRing : IItem
    {
        public IRing(string name, double weight, string imagePath, string documentationPath) : base(name, weight, imagePath, documentationPath)
        {
        }
    }
}