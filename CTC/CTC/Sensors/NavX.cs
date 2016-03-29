using WPILib;
using WPILib.Extras.NavX;

namespace CTC.Sensors
{
    internal static class NavX
    {
        private static readonly AHRS navx = new AHRS(SPI.Port.MXP);

        public static double GetAngle()
        {
            return navx.GetAngle();
        }
    }
}
