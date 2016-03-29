﻿using System;
using System.Threading;
using ACILIBj;
using CTC.Subsystems;
using WPILib.SmartDashboard;

namespace CTC
{
    /// <summary>
    /// This class is used to bind the joysticks to robot functions. 
    /// </summary>
    internal static class JoystickBinder
    {
        public static bool MacMode { get; set; }

        // Define and instantiate joysticks
        private static readonly SuperJoystick Driver = new SuperJoystick(Ports.JoystickDriver);
        private static readonly SuperJoystick Operator = new SuperJoystick(Ports.JoystickOperator);

        /// <summary>
        /// Bind joystick actions to robot functions. This function is called periodically.
        /// </summary>
        public static void Update()
        {
            // Analog axis binds
            DriveBase.Drive(Driver);

            if (!MacMode)
            {
                Arm.SetArm(Operator.GetAxis(SuperJoystick.Axis.RY, 0.1, -1, false));
                Arm.SetIntake(Operator.GetAxis(SuperJoystick.Axis.LY, 0.1, -1, false));

                Portcullis.Set(Driver.GetButtonDouble(SuperJoystick.Button.RB, 0.8)
                             - Driver.GetButtonDouble(SuperJoystick.Button.LB, 0.8));
            }
            else
            {
                Arm.SetIntake(Driver.GetButtonDouble(SuperJoystick.Button.LB, 1) -
                              Driver.GetButtonDouble(SuperJoystick.Button.RB, 1));

                Arm.SetArm((Driver.GetAxis(SuperJoystick.Axis.RT, 0, 1, false) -
                           Driver.GetAxis(SuperJoystick.Axis.LT, 0, 1, false)));

                Portcullis.Set(Driver.GetButtonDouble(SuperJoystick.Button.X, 0.8)
                             - Driver.GetButtonDouble(SuperJoystick.Button.B, 0.8));
            }

            // Button binds
            Driver.RunWhenPressed(SuperJoystick.Button.Back, ToggleGhettoShift);
            Driver.RunWhenPressed(SuperJoystick.Button.Start, () => MacMode = !MacMode);
            Driver.RunWhenPressed(SuperJoystick.Button.A, ToggleFront);

            // Dashboard

            SmartDashboard.PutBoolean("Mac Mode", MacMode);

        }
        
        private static void ToggleGhettoShift()
        {
            DriveBase.SpeedMultiplier = Math.Abs(DriveBase.SpeedMultiplier - 1) < 0.5 ? 0.5 : 1;
        }

        private static void ToggleFront()
        {
            var rumbleThread = new Thread(RumbleThread);
            DriveBase.ToggleFront = !DriveBase.ToggleFront;
            rumbleThread.Start();
        }

        private static void RumbleThread()
        {
            Driver.SetRumble(0.8f, SuperJoystick.RumbleType.Right);
            Thread.Sleep(200);
            Driver.SetRumble(0, SuperJoystick.RumbleType.All);
        }
    }

}
