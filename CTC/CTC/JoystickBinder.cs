using ACILIBj;
using CTC.Subsystems;

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

        // Define and instantiate a subsystem controller (contains all logic for the subsystems)
        private static readonly SubsystemController S = new SubsystemController();

        /// <summary>
        /// Bind joystick actions to robot functions. This function is called periodically.
        /// </summary>
        public static void Update()
        {
            // Analog axis binds
            DriveBase.Drive(Driver);

            if (!MacMode)
            {
                S.SetArmPower(Operator.GetAxis(SuperJoystick.Axis.RY, 0.17, -1));
                S.SetIntakePower(Operator.GetAxis(SuperJoystick.Axis.LY, 0.17, -1));

                S.SetPortcullisPower(Operator.GetAxis(SuperJoystick.Axis.RT, 0, 1) -
                                     Operator.GetAxis(SuperJoystick.Axis.LT, 0, 1));
            }
            else
            {
                S.SetIntakePower(Driver.GetButtonDouble(SuperJoystick.Button.LB, 1) - 
                                 Driver.GetButtonDouble(SuperJoystick.Button.RB, 1));

                S.SetArmPower(Driver.GetAxis(SuperJoystick.Axis.RT, 0, 1) - 
                              Driver.GetAxis(SuperJoystick.Axis.LT, 0, 1));
            }

            // Button binds
            Driver.RunWhenPressed(SuperJoystick.Button.A, () => S.ToggleGhettoShift());
            Driver.RunWhenPressed(SuperJoystick.Button.Y, () => S.ToggleRobotFront());
            Driver.RunWhenPressed(SuperJoystick.Button.Start, () => S.ToggleMacMode());
        }

    }

}
