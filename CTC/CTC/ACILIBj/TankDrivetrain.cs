using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;

namespace ACILIBj
{
    /// <summary>
    /// This class is used to control tank drivetrains.
    /// </summary>
    class TankDrivetrain
    {
        // Declare left and right speed controller arrays. 
        private readonly PWMSpeedControllerArray Left;
        private readonly PWMSpeedControllerArray Right;

        /// <summary>
        /// Class constructors. Includes overloads for 2, 4, and 6 CIM drivetrains
        /// </summary>
        /// <param name="L1">Left side speed controller(s)</param>
        /// <param name="R1">Right side speed controller(s)</param>
        public TankDrivetrain(PWMSpeedController L1, PWMSpeedController R1)
        {
            this.Left = new PWMSpeedControllerArray(new PWMSpeedController[] { L1 });
            this.Right = new PWMSpeedControllerArray(new PWMSpeedController[] { R1 });
        }

        public TankDrivetrain(PWMSpeedController L1, PWMSpeedController L2, PWMSpeedController R1, PWMSpeedController R2)
        {
            this.Left = new PWMSpeedControllerArray(new PWMSpeedController[] { L1, L2 });
            this.Right = new PWMSpeedControllerArray(new PWMSpeedController[] { R1, R2 });
        }

        public TankDrivetrain(PWMSpeedController L1, PWMSpeedController L2, PWMSpeedController L3,
                              PWMSpeedController R1, PWMSpeedController R2, PWMSpeedController R3)
        {
            this.Left = new PWMSpeedControllerArray(new PWMSpeedController[] { L1, L2, L3 });
            this.Right = new PWMSpeedControllerArray(new PWMSpeedController[] { R1, R2, R3 });
        }

        /// <summary>
        /// Sets the left and right side motors to the provided values
        /// with no extra processing
        /// </summary>
        /// <param name="leftSpeed">Left side speed</param>
        /// <param name="rightSpeed">Right side speed</param>
        public void SetRaw(double leftSpeed, double rightSpeed)
        {
            Left.Set(leftSpeed);
            Right.Set(rightSpeed);
        }

        /// <summary>
        /// Drives the drivetrain using the left and right sticks
        /// for left and right sides respectively
        /// </summary>
        /// <param name="leftSpeed">Left side speed</param>
        /// <param name="rightSpeed">Right side speed</param>
        /// <param name="speedMod">Speed multiplier</param>
        public void DriveTank(double leftSpeed, double rightSpeed, double speedMod)
        {
            Left.Set(leftSpeed * speedMod);
            Right.Set(-rightSpeed * speedMod);
        }

        /// <summary>
        /// Drives the robot using the left stick as forward/backward and
        /// the right stick as left/right
        /// </summary>
        /// <param name="leftStick">Left thumbstick value</param>
        /// <param name="rightStick">Right thumbstick value</param>
        /// <param name="speedMod">Speed multiplier</param>
        public void DriveHalo(double leftStick, double rightStick, double speedMod)
        {
            Left.Set((leftStick + rightStick) * speedMod);
            Right.Set((leftStick - rightStick) * -speedMod);
        }
    }
}
