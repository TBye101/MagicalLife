using MagicalLifeGUIWindows.Input.Specialized_Handlers;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Holds all of the specialized input handlers.
    /// </summary>
    public static class InputHandlers
    {
        public static LivingMoveOrderInputHandler LivingMove;

        public static LogoSkip LogoSkipper;

        public static MiningActionHandler MiningAction;

        public static StrafeHandler StrafingHandler = new StrafeHandler();

        public static EscapeHandler EscHandler = new EscapeHandler();

        public static ZoomHandler ZooomHandler = new ZoomHandler();

        public static void Initialize()
        {
            LivingMove = new LivingMoveOrderInputHandler();
            LogoSkipper = new LogoSkip();
            MiningAction = new MiningActionHandler();
        }
    }
}