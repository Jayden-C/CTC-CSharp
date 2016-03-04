using ACILIBj;
using CTC.Subsystems;

namespace CTC
{
    /// <summary>
    /// This class is used to bind the joysticks to robot functions. 
    /// </summary>
    internal static class JoystickBinder
    {
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
            S.SetArmPower(Operator.GetAxis(5, 0.17, -1));
            S.SetIntakePower(Operator.GetAxis(1, 0.17, -1));
            
            // Button binds
            Driver.RunWhenPressed(() => S.ToggleGhettoShift(), 1);
        }

    }

}
