using System;
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
                Arm.SetArm(Operator.GetAxis(SuperJoystick.Axis.RY, 0.17, -1));
                Arm.SetIntake(Operator.GetAxis(SuperJoystick.Axis.LY, 0.17, -1));

                Portcullis.Set(Operator.GetAxis(SuperJoystick.Axis.RT, 0, 1) -
                               Operator.GetAxis(SuperJoystick.Axis.LT, 0, 1));
            }
            else
            {
                Arm.SetIntake(Driver.GetButtonDouble(SuperJoystick.Button.LB, 1) - 
                              Driver.GetButtonDouble(SuperJoystick.Button.RB, 1));

                Arm.SetArm(Driver.GetAxis(SuperJoystick.Axis.RT, 0, 1) - 
                           Driver.GetAxis(SuperJoystick.Axis.LT, 0, 1));

                Portcullis.Set(Driver.GetButtonDouble(SuperJoystick.Button.X, 0.8)
                             - Driver.GetButtonDouble(SuperJoystick.Button.B, 0.8));
            }

            // Button binds
            Driver.RunWhenPressed(SuperJoystick.Button.A, ToggleGhettoShift);
            Driver.RunWhenPressed(SuperJoystick.Button.Y, () => DriveBase.ToggleFront = !DriveBase.ToggleFront);
            Driver.RunWhenPressed(SuperJoystick.Button.Start, () => MacMode = !MacMode);
    
        }
        
        private static void ToggleGhettoShift()
        {
            DriveBase.SpeedMultiplier = Math.Abs(DriveBase.SpeedMultiplier - 1) < 0.5 ? 0.5 : 1;
        }
    }

}
