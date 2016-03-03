using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;

namespace ACILIBj
{
    /// <summary>
    /// This class adds functionality to the existing WPI Joystick class.
    /// Its purpose is to make the use of Joysticks easier and faster.
    /// </summary>
    class SuperJoystick
    {
        // Declare joystick
        private readonly Joystick Joy;
        private bool Pre = false;

        /// <summary>
        /// Enum for joystick POV directions
        /// </summary>
        public enum Direction
        {
            UP, DOWN, RIGHT, LEFT
        }

        /// <summary>
        /// Enum for controller rumble types
        /// </summary>
        public enum RumbleType
        {
            LEFT, RIGHT, ALL
        }

        /// <summary>
        /// Constructor for SuperJoystick class
        /// </summary>
        /// <param name="port">Desired port</param>
        public SuperJoystick(int port)
        {
            // Create exception in case negative port is provided
            if (port < 0)
            {
                throw new ArgumentOutOfRangeException("Joystick port must not be negative!");
            }

            // Instantiate joystick with provided port
            Joy = new Joystick(port);
        }

        /// <summary>
        /// Returns the value of an analog axis on the controller
        /// </summary>
        /// <param name="axis">Axis number</param>
        /// <param name="deadzone">Dead zone</param>
        /// <param name="multiplier">Multiplier</param>
        /// <returns>Value of specified axis with dead zone</returns>
        public double GetAxis(int axis, double deadzone, double multiplier)
        {
            // If axis value is within specified dead zone, return 0. Otherwise return axis value
            return Math.Abs(Joy.GetRawAxis(axis)) <= deadzone ? 0 : Joy.GetRawAxis(axis) * multiplier;
        }

        /// <summary>
        /// Runs the provided delegate when the button is pressed.
        /// </summary>
        /// <param name="runner">Delegate to be run</param>
        /// <param name="button">Desired button</param>
        public void RunWhenPressed(Action runner, int button)
        {
            if (Joy.GetRawButton(button) && !Pre)
            {
                runner();
                Pre = true;
            }
            else if (!Joy.GetRawButton(button))
            {
                Pre = false;
            }
        }

        /// <summary>
        /// Runs the provided delegate when the button is released
        /// </summary>
        /// <param name="runner">Delegate to be run</param>
        /// <param name="button">Desired button</param>
        public void RunWhenReleased(Action runner, int button)
        {
            if (!Joy.GetRawButton(button) && !Pre)
            {
                runner();
                Pre = true;
            }
            else if (Joy.GetRawButton(button))
            {
                Pre = false;
            }
        }

        /// <summary>
        /// Runs the provided delegate repeatedly while the button is pressed
        /// </summary>
        /// <param name="runner">Delegate to be run</param>
        /// <param name="button">Desired button</param>
        public void RunWhilePressed(Action pressed, int button, Action released = null)
        {
            if (Joy.GetRawButton(button))
            {
                pressed();
            }
            else if (!Joy.GetRawButton(button) && released != null)
            {
                released();
            }
        }

        /// <summary>
        /// Returns the state of the specified button
        /// </summary>
        /// <param name="button">Button number</param>
        /// <returns>State of the specified button (T or F)</returns>
        public bool GetButton(int button)
        {
            return Joy.GetRawButton(button);
        }

        /// <summary>
        /// Returns the state of the specified POV angle. 
        /// POVs on joysticks are different than buttons in that they return
        /// their angle rather than a boolean value. This method converts an 
        /// angle value into a boolean so that the POV can be used as a set of buttons
        /// </summary>
        /// <param name="d">Direction of the POV</param>
        /// <returns></returns>
        public bool GetPOV(Direction d)
        {
            switch (d)
            {
                case Direction.UP:
                    return Joy.GetPOV(0) == 0;
                case Direction.DOWN:
                    return Joy.GetPOV(0) == 180;
                case Direction.RIGHT:
                    return Joy.GetPOV(0) == 90;
                case Direction.LEFT:
                    return Joy.GetPOV(0) == 270;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Sets the rumble motors in the controller, useful for feedback to the drivers
        /// </summary>
        /// <param name="power">Power level of rumble</param>
        /// <param name="r">Rumble type (Left, Right, or both)</param>
        public void SetRumble(float power, RumbleType r)
        {
            switch (r)
            {
                case RumbleType.LEFT:
                    Joy.SetRumble(Joystick.RumbleType.LeftRumble, power);
                    break;
                case RumbleType.RIGHT:
                    Joy.SetRumble(Joystick.RumbleType.RightRumble, power);
                    break;
                case RumbleType.ALL:
                    Joy.SetRumble(Joystick.RumbleType.LeftRumble, power);
                    Joy.SetRumble(Joystick.RumbleType.RightRumble, power);
                    break;
                default:
                    break;
            }
        }
    }
}
