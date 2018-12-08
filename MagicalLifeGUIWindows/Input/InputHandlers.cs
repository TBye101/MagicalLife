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

        public static StrafeHandler StrafingHandler;

        public static TillingActionHandler TillingAction;

        public static EscapeHandler EscHandler;

        public static ZoomHandler ZooomHandler;

        public static void Initialize()
        {
            LivingMove = new LivingMoveOrderInputHandler();
            LogoSkipper = new LogoSkip();
            MiningAction = new MiningActionHandler();
            TillingAction = new TillingActionHandler();
            StrafingHandler = new StrafeHandler();
            EscHandler = new EscapeHandler();
            ZooomHandler = new ZoomHandler();
        }
    }
}