using System;
using CTC.Autonomous;
using CTC.Sensors;
using WPILib;
using WPILib.SmartDashboard;

namespace CTC
{
    public class CTC : IterativeRobot
    {
        private static readonly AutoChooser Auto = new AutoChooser();

        private static bool _autoRan;

        public override void RobotInit()
        {
            Auto.PutData();
            //LowGoalAuto.InitGyro();
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
            }
        }
    }
}
