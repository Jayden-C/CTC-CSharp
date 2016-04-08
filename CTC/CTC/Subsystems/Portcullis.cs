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
        /// Extends the portcullis ramp.
        /// </summary>
        internal static bool DeployBool()
        {
            var timeout = 0;

            while (LimitSwitchOut.Get() && timeout < 100)
            {
                PortcullisMotor.Set(-0.9);
                timeout++;
                Thread.Sleep(20);
            }
            PortcullisMotor.Set(0);

            if (timeout < 100) return true;
            return false;
        }

        internal static void Deploy()
        {
            var timeout = 0;

            while (LimitSwitchOut.Get() && timeout < 100)
            {
                PortcullisMotor.Set(-0.9);
                timeout++;
                Thread.Sleep(20);
            }
            PortcullisMotor.Set(0);
        }

        /// <summary>
        /// Retracts the portcullis ramp.
        /// </summary>
        internal static bool RetractBool()
        {
            var timeout = 0;

            while (LimitSwitchIn.Get() && timeout < 100)
            {
                PortcullisMotor.Set(0.9);
                timeout++;
                Thread.Sleep(20);
            }
            PortcullisMotor.Set(0);

            if (timeout < 100) return true;
            return false;
        }

        internal static void Retract()
        {
            var timeout = 0;

            while (LimitSwitchIn.Get() && timeout < 100)
            {
                PortcullisMotor.Set(0.9);
                timeout++;
                Thread.Sleep(20);
            }
            PortcullisMotor.Set(0);
        }

    }
}
