using ACILIBj;
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
    /// This class contains all code for the drivetrain.
    /// </summary>
    static class DriveBase
    {
        // Define and instantiate speed controllers
        private static readonly Victor L1 = new Victor(Ports.LEFT_MOTOR_1);
        private static readonly Victor L2 = new Victor(Ports.LEFT_MOTOR_2);
        private static readonly Victor R1 = new Victor(Ports.RIGHT_MOTOR_1);
        private static readonly Victor R2 = new Victor(Ports.RIGHT_MOTOR_2);

        // Define and instantiate drivetrain
        private static readonly TankDrivetrain Drivetrain = new TankDrivetrain(L1, L2, R1, R2);

        // Multiplier which makes turning more consistent
        private static double TurnMultiplier = 1.0;
        
        public static void DriveHalo(SuperJoystick Joy)
        {
            // Change turn multiplier based on robot speed
            if(Joy.GetAxis(1, 0.12, -1) == 0.2)
            {
                TurnMultiplier = 1;
            }
            else
            {
                TurnMultiplier = 0.74;
            }
            SmartDashboard.PutNumber("Turn Mult", TurnMultiplier);
            Drivetrain.DriveHalo(Joy.GetAxis(1, 0.12, -1), Joy.GetAxis(4, 0.12, 1) * TurnMultiplier, 1);
        }
    }
}
