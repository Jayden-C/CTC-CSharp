using WPILib;
using WPILib.Extras.NavX;

namespace CTC.Sensors
{
    internal static class NavX
    {
        private static readonly AHRS navx = new AHRS(SPI.Port.MXP);

        /// <summary>
        /// Returns the angle of the NavX
        /// </summary>
        /// <returns>Angle</returns>
        public static double GetAngle()
        {
            return navx.GetAngle();
        }
    }
}
