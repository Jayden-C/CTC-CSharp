﻿using System.Threading;
using WPILib;
using WPILib.SmartDashboard;

namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all code for the arm subsystem (arm itself + intake)
    /// </summary>
    internal static class Arm
    {
        // Declare and instantiate speed controllers
        private static readonly CANTalon ArmLeft = new CANTalon(Ports.ArmMotorLeft);
        private static readonly CANTalon ArmRight = new CANTalon(Ports.ArmMotorRight);
        private static readonly Victor Intake = new Victor(Ports.IntakeMotor);

        // Declare and instantiate limit switch
        private static readonly DigitalInput LimitSwitchFront = new DigitalInput(Ports.LimitSwitchFront);
        private static readonly DigitalInput LimitSwitchBack = new DigitalInput(Ports.LimitSwitchBack);
        private static readonly DigitalInput LimitSwitchBall = new DigitalInput(Ports.LimitSwitchBall);

        public static void SetIntake(double power)
        {
            Intake.Set(-power);
        }

        public static void SetArm(double power)
        {
            power *= 0.7;

            SmartDashboard.PutBoolean("Limit Switch Front", LimitSwitchFront.Get());
            SmartDashboard.PutBoolean("Limit Switch Back", LimitSwitchBack.Get());

            // If arm is at the bottom, only allow it to move up
            if (!LimitSwitchFront.Get())
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
            else if (!LimitSwitchBack.Get())
            {
                if (power <= 0)
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

        /// <summary>
        /// Lowers arm until it hits the limit switch
        /// </summary>
        internal static void Lower()
        {
            while (LimitSwitchFront.Get())
            {
                ArmLeft.Set(-0.5);
                ArmRight.Set(0.5);
                Thread.Sleep(20);
            }
            ArmLeft.Set(0);
            ArmRight.Set(0);
        }

        /// <summary>
        /// Raises arm until it hits the limit switch
        /// </summary>
        internal static void Raise()
        {
            while (LimitSwitchBack.Get())
            {
                ArmLeft.Set(0.5);
                ArmRight.Set(-0.5);
                Thread.Sleep(20);
            }
            ArmLeft.Set(0);
            ArmRight.Set(0);
        }

        internal static bool GetBallLimitSwitch()
        {
            return !LimitSwitchBall.Get();
        }

    }
}
