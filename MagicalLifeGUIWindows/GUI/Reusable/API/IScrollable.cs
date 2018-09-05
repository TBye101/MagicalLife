namespace MagicalLifeGUIWindows.GUI.Reusable.API
{
    /// <summary>
    /// Anything that implements this can be scrolled forward and backward by external calls.
    /// </summary>
    public interface IScrollable
    {
        void Forward();

        void Backwards();
    }
}