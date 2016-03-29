using System.Threading;
using CTC.Subsystems;
using WPILib;
using WPILib.SmartDashboard;

namespace CTC.Autonomous
{
    internal static class LowGoalAuto
    {
        private static AnalogGyro _gyro;

        internal static void InitGyro()
        {
            _gyro  = new AnalogGyro(Ports.Gyro);
        }

        internal static void Run()
        {
            Arm.Lower();
            DriveBase.DriveTime(700, 0.35);
            DriveBase.DriveTime(1678, 0.5);
            Thread.Sleep(1000);

            while (_gyro.GetAngle() < 32.5)
            {
                DriveBase.SetRaw(0.8, 0.8);
                SmartDashboard.PutNumber("Gyro in auto thread safe", _gyro.GetAngle());
                Thread.Sleep(20);
            }

            DriveBase.DriveTime(2000, 0.37);
            Arm.SetIntake(1);
        }

        internal static void Abort()
        {
            Arm.SetIntake(0);
            DriveBase.DriveTime(1, 0);
        }
    }
}
