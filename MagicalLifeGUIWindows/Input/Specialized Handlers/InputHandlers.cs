namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Holds all of the specialized input handlers.
    /// </summary>
    public static class InputHandlers
    {
        public static LivingMoveOrderInputHandler LivingMove;

        public static void Initialize()
        {
            LivingMove = new LivingMoveOrderInputHandler();
        }
    }
}