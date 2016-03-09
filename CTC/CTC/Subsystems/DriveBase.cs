using System;
using System.Threading;
using ACILIBj;
using WPILib;
using WPILib.SmartDashboard;

namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all code for the drivetrain.
    /// </summary>
    internal static class DriveBase
    {
        // Define and instantiate speed controllers
        private static readonly Victor L1 = new Victor(Ports.LeftMotor1);
        private static readonly Victor L2 = new Victor(Ports.LeftMotor2);
        private static readonly Victor R1 = new Victor(Ports.RightMotor1);
        private static readonly Victor R2 = new Victor(Ports.RightMotor2);

        // Define and instantiate drivetrain
        private static readonly TankDrivetrain Drivetrain = new TankDrivetrain(L1, L2, R1, R2);

        // Toggle which side of the robot is the front
        internal static bool ToggleFront { get; set; } = false;

        // Multiplier which makes turning more consistent
        private static double TurnMultiplier { get; set; } = 1.0;

        // Multiplier which allows for a "ghetto shifter"
        internal static double SpeedMultiplier { get; set; } = 1.0;

        public static void Drive(SuperJoystick joy)
        {
            // Change turn multiplier based on robot speed
            TurnMultiplier = Math.Abs(joy.GetAxis(SuperJoystick.Axis.LY, 0.12, -1)) < 0.4 ? 1 : 0.74;

            SmartDashboard.PutNumber("Turn Multiplier", TurnMultiplier);
            SmartDashboard.PutNumber("Speed Multiplier", SpeedMultiplier);
            SmartDashboard.PutBoolean("Robot Front Toggle", ToggleFront);

            Drivetrain.DriveHalo(
                ToggleFront ? joy.GetAxis(SuperJoystick.Axis.LY, 0.12, 1) : joy.GetAxis(SuperJoystick.Axis.LY, 0.12, -1),
                joy.GetAxis(SuperJoystick.Axis.RX, 0.12, 1)
                *TurnMultiplier, SpeedMultiplier);
        }

        public static void DriveTime(int time, double power)
        {
            Drivetrain.SetRaw(power, -power);
            Thread.Sleep(time);
            Drivetrain.SetRaw(0, 0);
        }
    }
}
