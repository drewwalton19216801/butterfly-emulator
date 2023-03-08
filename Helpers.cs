namespace Butterfly.Helpers
{
    public static class ClockSpeed
    {
        public static Int64 mhzToHz(float mhz)
        {
            return (Int64)(mhz * 1000000);
        }

        public static float hzToMhz(Int64 hz)
        {
            return (float)hz / 1000000;
        }
    }
}