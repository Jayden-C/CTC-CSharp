using CTC.Autonomous;
using WPILib;

namespace CTC
{
    public class CTC : IterativeRobot
    {
        private static readonly AutoChooser Auto = new AutoChooser();

        private static bool _autoRan;

        public override void RobotInit()
        {
            Auto.PutData();
        }

        public override void AutonomousInit()
        {
            
        }

        public override void AutonomousPeriodic()
        {
            if (_autoRan) return;
            Auto.Run();
            _autoRan = true;
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
