using WPILib;

namespace CTC.Subsystems
{
    internal static class Climber
    {
        private static readonly Victor TapeMeasures = new Victor(Ports.TapeMeasureMotor);
        private static readonly Talon WinchMotor1 = new Talon(Ports.WinchMotor1);
        private static readonly Talon WinchMotor2 = new Talon(Ports.WinchMotor2);

        public static void SetTapes(double power)
        {
            TapeMeasures.Set(power * 0.5);
        }

        public static void WinchIn()
        {
            WinchMotor1.Set(1);
            WinchMotor2.Set(1);
        }

        public static void WinchOut()
        {
            WinchMotor1.Set(-1);
            WinchMotor2.Set(-1);
        }

        public static void WinchStop()
        {
            WinchMotor1.Set(0);
            WinchMotor2.Set(0);
        }
    }
}
