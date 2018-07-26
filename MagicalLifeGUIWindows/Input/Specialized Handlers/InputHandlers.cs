namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Holds all of the specialized input handlers.
    /// </summary>
    public static class InputHandlers
    {
        public static LivingMoveOrderInputHandler LivingMove;

        public static LogoSkip LogoSkipper;

        public static MiningActionHandler MiningAction;

        public static void Initialize()
        {
            LivingMove = new LivingMoveOrderInputHandler();
            LogoSkipper = new LogoSkip();
            MiningAction = new MiningActionHandler();
        }
    }
}