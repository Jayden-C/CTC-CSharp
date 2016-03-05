namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all of the logic for controlling the robot's subsystems.
    /// </summary>
    internal class SubsystemController
    {
        private bool _ghettoShiftToggle;

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