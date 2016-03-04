using WPILib;

namespace CTC
{

    public class CTC : IterativeRobot
    {
        
        public override void RobotInit()
        {
            
        }

        public override void AutonomousInit()
        {

        }

        public override void AutonomousPeriodic()
        {

        }

        public override void TeleopPeriodic()
        {
            JoystickBinder.Update();
        }

        public override void TestPeriodic()
        {

        }
    }
}
