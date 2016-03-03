using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACILIBj;

namespace CTC.Subsystems
{
    /// <summary>
    /// This class contains all of the logic for controlling the robot's subsystems.
    /// </summary>
    class SubsystemController
    {
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

        public void Drive(SuperJoystick joy)
        {

        }
    }
}