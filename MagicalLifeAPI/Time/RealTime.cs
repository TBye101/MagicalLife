namespace MagicalLifeAPI.Time
{
    /// <summary>
    /// Knows various things about real life time, measured in ticks.
    /// </summary>
    public static class RealTime
    {
        public static readonly int Second = 17;

        public static readonly int Minute = Second * 60;

        public static readonly int HalfHour = Minute * 30;

        public static readonly int Hour = Minute * 60;

        public static readonly int Day = Hour * 24;

        public static readonly int Week = Day * 7;

        public static readonly int January = Day * 31;

        public static readonly int FebruaryNonLeap = Day * 28;
        public static readonly int FebruaryLeap = Day * 29;

        public static readonly int March = Day * 31;

        public static readonly int April = Day * 30;

        public static readonly int May = Day * 31;

        public static readonly int June = Day * 30;

        public static readonly int July = Day * 31;

        public static readonly int August = Day * 31;

        public static readonly int September = Day * 30;

        public static readonly int October = Day * 31;

        public static readonly int November = Day * 30;

        public static readonly int December = Day * 31;
    }
}