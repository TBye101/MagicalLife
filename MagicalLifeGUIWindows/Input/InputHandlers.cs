using MagicalLifeGUIWindows.Input.Specialized_Handlers;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Holds all of the specialized input handlers.
    /// </summary>
    public static class InputHandlers
    {
        public static LivingMoveOrderInputHandler LivingMove { get; set; }

        public static LogoSkip LogoSkipper { get; set; }

        public static MiningActionHandler MiningAction { get; set; }

        public static ChopActionHandler ChopAction { get; set; }

        public static StrafeHandler StrafingHandler { get; set; }

        public static TillingActionHandler TillingAction { get; set; }

        public static EscapeHandler EscHandler { get; set; }

        public static ZoomHandler ZooomHandler { get; set; }

        public static LivingMenuHandler LivingMenuHandler { get; set; }

        public static ContainerDragHandler DragHandler { get; set; }

        public static void Initialize()
        {
            LivingMove = new LivingMoveOrderInputHandler();
            LogoSkipper = new LogoSkip();
            MiningAction = new MiningActionHandler();
            TillingAction = new TillingActionHandler();
            StrafingHandler = new StrafeHandler();
            EscHandler = new EscapeHandler();
            ZooomHandler = new ZoomHandler();
            ChopAction = new ChopActionHandler();
            LivingMenuHandler = new LivingMenuHandler();
            DragHandler = new ContainerDragHandler();
        }
    }
}