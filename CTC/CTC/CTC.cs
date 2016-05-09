using System;
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
            Auto.GetChoice(2);
        }

        public override void AutonomousPeriodic()
        {
            if (_autoRan) return;

            Console.WriteLine("AUTO RAN");
            Auto.Run();
            _autoRan = true;
        }

        public override void TeleopInit()
        {
            if (!_autoRan) return;
            Auto.Abort();
            Console.WriteLine("ABORTING AUTO");
            _autoRan = false;
        }

        public override void TeleopPeriodic()
        {
            JoystickBinder.Update();
        }

        public override void TestPeriodic()
        {

        }

        public override void DisabledInit()
        {
            if (!_autoRan) return;
            Console.WriteLine("ABORTING AUTO");
            Auto.Abort();
            _autoRan = false;
        }
    }
}
