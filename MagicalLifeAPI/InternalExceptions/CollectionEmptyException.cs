namespace MagicalLifeAPI.InternalExceptions
{
    public class CollectionEmptyException : System.Exception
    {
        public CollectionEmptyException() : base("Collection empty!")
        {
        }

        public CollectionEmptyException(string msg) : base(msg)
        {
        }
    }
}