using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;
using ACILIBj;
using CTC.Subsystems;

namespace CTC
{
    /// <summary>
    /// This class is used to bind the joysticks to robot functions. 
    /// </summary>
    static class JoystickBinder
    {
        // Define and instantiate joysticks
        private static readonly SuperJoystick Driver = new SuperJoystick(Ports.JOYSTICK_DRIVER);
        private static readonly SuperJoystick Operator = new SuperJoystick(Ports.JOYSTICK_OPERATOR);

        // Define and instantiate a subsystem controller (contains all logic for the subsystems)
        private static readonly SubsystemController S = new SubsystemController();

        /// <summary>
        /// Bind joystick actions to robot functions. This function is called periodically.
        /// </summary>
        public static void Update()
        {
            DriveBase.DriveHalo(Driver);
            S.SetArmPower(Operator.GetAxis(5, 0.17, -1));
            S.SetIntakePower(Operator.GetAxis(1, 0.17, -1));
        }

    }

}
