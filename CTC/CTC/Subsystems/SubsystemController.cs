using System;
using ACILIBj;

namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all of the logic for controlling the robot's subsystems.
    /// </summary>
    internal class SubsystemController
    {
        private bool _ghettoShiftToggle = false;

        public SubsystemController()
        {

        }

        public void IntakeIn()
        {
            Arm.SetIntake(1);
        }
        public void IntakeOut()
        {
            Arm.SetIntake(-1);
        }

        public void IntakeStop()
        {
            Arm.SetIntake(0);
        }

        public void SetArmPower(double power)
        {
            Arm.SetArm(power);
        }
        
        public void SetIntakePower(double power)
        {
            Arm.SetIntake(power);
        }

        public void ToggleGhettoShift()
        {
            _ghettoShiftToggle = !_ghettoShiftToggle;
            DriveBase.SpeedMultiplier = _ghettoShiftToggle ? 0.5 : 1;
        }
    }
}