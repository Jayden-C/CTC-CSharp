using System;
using System.IO;
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

        private static double TurnMultiplier { get; } = 0.7;
        internal static double SpeedMultiplier { get; set; } = 1.0;

        public static void Drive(SuperJoystick joy)
        {
            // Change turn multiplier based on robot speed
            //TurnMultiplier = Math.Abs(joy.GetAxis(SuperJoystick.Axis.LY, 0.12, -1, false)) < 0.4 ? 1 : 0.74;

            SmartDashboard.PutNumber("Turn Multiplier", TurnMultiplier);
            SmartDashboard.PutNumber("Speed Multiplier", SpeedMultiplier);
            SmartDashboard.PutBoolean("Robot Front Toggle", ToggleFront);

            Drivetrain.DriveHalo(
                ToggleFront ? joy.GetAxis(SuperJoystick.Axis.LY, 0.08, 1, true) : joy.GetAxis(SuperJoystick.Axis.LY, 0.08, -1, true),
                joy.GetAxis(SuperJoystick.Axis.RX, 0.08, 1, false)
                *1, SpeedMultiplier);
        }

        /// <summary>
        /// Drives the robot forward or backward for a set amount of time
        /// </summary>
        /// <param name="time">Amount of time to drive</param>
        /// <param name="power">Power to drive at</param>
        public static void DriveTime(int time, double power)
        {
            Drivetrain.SetRaw(power, -power);
            Thread.Sleep(time);
            Drivetrain.SetRaw(0, 0);
        }

        /// <summary>
        /// Sets the left and right side of the drivetrain to the provided values
        /// </summary>
        /// <param name="leftPower">Left side power</param>
        /// <param name="rightPower">Right side power</param>
        public static void SetRaw(double leftPower, double rightPower)
        {
            Drivetrain.SetRaw(leftPower, rightPower);
        }
        
    }
}
