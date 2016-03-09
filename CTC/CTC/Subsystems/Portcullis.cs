using System.Threading;
using WPILib;
using WPILib.SmartDashboard;

namespace CTC.Subsystems
{
    /// <summary>
    /// Static class responsible for controlling the portcullis wedge/ramp
    /// </summary>
    internal static class Portcullis
    {
        private static readonly Talon PortcullisMotor = new Talon(Ports.PortcullisMotor);

        private static readonly DigitalInput LimitSwitchOut = new DigitalInput(Ports.LimitSwitchOut);
        private static readonly DigitalInput LimitSwitchIn = new DigitalInput(Ports.LimitSwitchIn);

        /// <summary>
        /// Sets the power of the portcullis motor with logic to make it stop once either
        /// limit switch is pressed.
        /// </summary>
        /// <param name="power"></param>
        public static void Set(double power)
        {
            SmartDashboard.PutBoolean("Limit Switch out", LimitSwitchOut.Get());
            SmartDashboard.PutBoolean("Limit switch in", LimitSwitchIn.Get());

            if (!LimitSwitchOut.Get())
            {
                PortcullisMotor.Set(-power < 0 ? 0 : -power);
            }
            else if (!LimitSwitchIn.Get())
            {
                PortcullisMotor.Set(-power > 0 ? 0 : -power);
            }
            else
            {
                PortcullisMotor.Set(-power);
            }

        }

        /// <summary>
        /// Extends the portcullis ramp. Intended to be used in a separate thread.
        /// </summary>
        public static void Deploy()
        {
            while (LimitSwitchOut.Get())
            {
                PortcullisMotor.Set(-0.7);
                Thread.Sleep(20);
            }
            PortcullisMotor.Set(0);
        }

        /// <summary>
        /// Retracts the portcullis ramp. Intended to be used in a separate thread.
        /// </summary>
        public static void Retract()
        {
            while (LimitSwitchIn.Get())
            {
                PortcullisMotor.Set(0.7);
                Thread.Sleep(20);
            }
            PortcullisMotor.Set(0);
        }
    }
}
