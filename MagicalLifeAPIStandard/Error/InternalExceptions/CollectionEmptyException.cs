namespace MagicalLifeAPI.Error.InternalExceptions
{
    internal class CollectionEmptyException : System.Exception
    {
        public CollectionEmptyException() : base("Collection empty!")
        {
        }

        public CollectionEmptyException(string msg) : base(msg)
        {
        }
    }
}