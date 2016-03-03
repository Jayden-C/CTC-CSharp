using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;
using ACILIBj;
using WPILib.SmartDashboard;

namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all code for the arm subsystem (arm itself + intake)
    /// </summary>
    static class Arm
    {
        // Declare and instantiate speed controllers
        private static readonly Talon ArmLeft = new Talon(Ports.ARM_MOTOR_LEFT);
        private static readonly Talon ArmRight = new Talon(Ports.ARM_MOTOR_RIGHT);
        private static readonly Talon Intake = new Talon(Ports.INTAKE_MOTOR);

        // Declare and instantiate limit switch
        private static readonly DigitalInput LimitSwitch = new DigitalInput(Ports.LIMIT_SWITCH);

        public static void SetIntake(double power)
        {
            Intake.Set(-power);
        }

        public static void SetArm(double power)
        {
            SmartDashboard.PutBoolean("Limit Switch", LimitSwitch.Get());

            // If arm is at the bottom, only allow it to move up
            if (!LimitSwitch.Get())
            {
                if (power >= 0)
                {
                    ArmLeft.Set(power);
                    ArmRight.Set(-power);
                }
                else
                {
                    ArmLeft.Set(0);
                    ArmRight.Set(0);
                }
            }
            else
            {
                ArmLeft.Set(power);
                ArmRight.Set(-power);
            }

        }
    }
}
