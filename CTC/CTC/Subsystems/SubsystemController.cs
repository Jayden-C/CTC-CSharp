using System;

namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all of the logic for controlling the robot's subsystems.
    /// </summary>
    internal class SubsystemController
    {

        public void SetArmPower(double power)
        {
            Arm.SetArm(power);
        }
        
        public void SetIntakePower(double power)
        {
            Arm.SetIntake(power);
        }

        public void SetPortcullisPower(double power)
        {
            Portcullis.Set(power);
        }

        public void ToggleRobotFront()
        {
            DriveBase.ToggleFront = !DriveBase.ToggleFront;
        }

        public void ToggleMacMode()
        {
            JoystickBinder.MacMode = !JoystickBinder.MacMode;
        }

        public void ToggleGhettoShift()
        {
            DriveBase.SpeedMultiplier = Math.Abs(DriveBase.SpeedMultiplier - 1) < 0.5 ? 0.5 : 1;
        }
    }
}