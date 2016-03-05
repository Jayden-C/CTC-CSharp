using System;
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
        private readonly Joystick _joy;
        private bool _pre;

        /// <summary>
        /// Enum for joystick POV directions
        /// </summary>
        public enum Direction
        {
            Up, Down, Right, Left
        }

        /// <summary>
        /// Enum for controller rumble types
        /// </summary>
        public enum RumbleType
        {
            Left, Right, All
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
                throw new ArgumentOutOfRangeException(nameof(port));
            }

            // Instantiate joystick with provided port
            _joy = new Joystick(port);
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
            return Math.Abs(_joy.GetRawAxis(axis)) <= deadzone ? 0 : _joy.GetRawAxis(axis) * multiplier;
        }

        /// <summary>
        /// Runs the provided delegate when the button is pressed.
        /// </summary>
        /// <param name="runner">Delegate to be run</param>
        /// <param name="button">Desired button</param>
        public void RunWhenPressed(Action runner, int button)
        {
            if (_joy.GetRawButton(button) && !_pre)
            {
                runner();
                _pre = true;
            }
            else if (!_joy.GetRawButton(button))
            {
                _pre = false;
            }
        }

        /// <summary>
        /// Runs the provided delegate when the button is released
        /// </summary>
        /// <param name="runner">Delegate to be run</param>
        /// <param name="button">Desired button</param>
        public void RunWhenReleased(Action runner, int button)
        {
            if (!_joy.GetRawButton(button) && !_pre)
            {
                runner();
                _pre = true;
            }
            else if (_joy.GetRawButton(button))
            {
                _pre = false;
            }
        }

        /// <summary>
        /// Runs the provided delegate repeatedly while the button is pressed
        /// </summary>
        /// <param name="pressed">Delegate to be run when pressed</param>
        /// <param name="button">Desired button</param>
        /// <param name="released">Delegate to be run when released</param>
        public void RunWhilePressed(Action pressed, int button, Action released = null)
        {
            if (_joy.GetRawButton(button))
            {
                pressed();
            }
            else if (!_joy.GetRawButton(button))
            {
                released?.Invoke();
            }
        }

        /// <summary>
        /// Returns the state of the specified button
        /// </summary>
        /// <param name="button">Button number</param>
        /// <returns>State of the specified button (T or F)</returns>
        public bool GetButton(int button)
        {
            return _joy.GetRawButton(button);
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
                case Direction.Up:
                    return _joy.GetPOV(0) == 0;
                case Direction.Down:
                    return _joy.GetPOV(0) == 180;
                case Direction.Right:
                    return _joy.GetPOV(0) == 90;
                case Direction.Left:
                    return _joy.GetPOV(0) == 270;
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
                case RumbleType.Left:
                    _joy.SetRumble(Joystick.RumbleType.LeftRumble, power);
                    break;
                case RumbleType.Right:
                    _joy.SetRumble(Joystick.RumbleType.RightRumble, power);
                    break;
                case RumbleType.All:
                    _joy.SetRumble(Joystick.RumbleType.LeftRumble, power);
                    _joy.SetRumble(Joystick.RumbleType.RightRumble, power);
                    break;
            }
        }
    }
}
