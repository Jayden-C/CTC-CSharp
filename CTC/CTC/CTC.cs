using System;
using CTC.Autonomous;
using WPILib;

namespace CTC
{
    public class CTC : IterativeRobot
    {
        private static readonly AutoChooser Auto = new AutoChooser();

        private static bool _autoRan;

        private static int AutoSelected = -1;

        public override void RobotInit()
        {
            Auto.PutData();
        }

        public override void AutonomousInit()
        {
            Auto.GetChoice(2);

            Console.WriteLine("Selected Auto: ");
            Console.Write(AutoSelected);
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
            if (_autoRan)
            {
                Auto.Abort();
                Console.WriteLine("ABORTING AUTO");
                _autoRan = false;
            }
                
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
            if (_autoRan)
            {
                Console.WriteLine("ABORTING AUTO");
                Auto.Abort();
                _autoRan = false;
            }
        }
    }
}
