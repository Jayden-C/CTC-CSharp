using System;
using WPILib;

namespace ACILIBj
{
    /// <summary>
    /// The purpose of this class is to group together multiple PWM speed controllers
    /// who's values will all be the same no matter what (Any motors in gearboxes essentially). 
    /// </summary>
    class PWMSpeedControllerArray
    {
        // Declare speed controller array
        private readonly PWMSpeedController[] _motorArray;

        /// <summary>
        /// Constructor for PWMSpeedControllerArray
        /// </summary>
        /// <param name="motorArray">Array of PWMSpeedController</param>
        public PWMSpeedControllerArray(PWMSpeedController[] motorArray)
        {
            // Ensure that array provided isn't empty
            if (motorArray.Length == 0)
            {
                throw new ArgumentNullException(nameof(motorArray));
            }
            _motorArray = motorArray;
        }

        /// <summary>
        /// Sets each speed controller in array
        /// </summary>
        /// <param name="power">Desired power</param>
        public void Set(double power)
        {
            foreach (var s in _motorArray)
            {
                s.Set(power);
            }
        }

        /// <summary>
        /// Sets PID power for each speed controller in array. This function should
        /// not be explicitly called by the user.
        /// </summary>
        /// <param name="value">PID generated value</param>
        public void PIDWrite(double value)
        {
            foreach(var s in _motorArray)
            {
                s.PidWrite(value);
            }
        }

        /// <summary>
        /// Disables each speed controller in array.
        /// </summary>
        public void Disable()
        {
            foreach (var s in _motorArray)
            {
                s.Disable();
            }
        }

        /// <summary>
        /// Stops each speed controller in array.
        /// </summary>
        public void StopMotor()
        {
            foreach(var s in _motorArray)
            {
                s.StopMotor();
            }
        }

        /// <summary>
        /// Disposes each speed controller in array.
        /// </summary>
        public void Dispose()
        {
            foreach(var s in _motorArray)
            {
                s.Dispose();
            }
        }
    }
}
