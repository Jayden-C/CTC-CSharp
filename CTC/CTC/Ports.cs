using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    /// <summary>
    /// Static class which contains constants for each port on the robot.
    /// </summary>
    static class Ports
    {
        public const int LEFT_MOTOR_1 = 0;
        public const int LEFT_MOTOR_2 = 1;
        public const int RIGHT_MOTOR_1 = 2;
        public const int RIGHT_MOTOR_2 = 3;

        public const int INTAKE_MOTOR = 4;
        public const int ARM_MOTOR_LEFT = 5;
        public const int ARM_MOTOR_RIGHT = 6;

        public const int LIMIT_SWITCH = 0;

        public const int JOYSTICK_DRIVER = 0;
        public const int JOYSTICK_OPERATOR = 1;
    }
}
