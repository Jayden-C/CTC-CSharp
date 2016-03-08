using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
