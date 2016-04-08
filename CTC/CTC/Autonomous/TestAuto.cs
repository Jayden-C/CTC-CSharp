using System;
using System.Threading;
using CTC.Subsystems;
using WPILib.SmartDashboard;
using PIDController = ACILIBj.PIDController;
using CTC.Sensors;

namespace CTC.Autonomous
{
    internal static class TestAuto
    {
        private static readonly PIDController TurnPid = new PIDController(0.025, 0.004, 0.8, 0.25 / 0.003, true);

        internal static void Run()
        {
            var initTime = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;

            while (true)
            {
                var error = 180 - NavX.GetAngle();

                var output = TurnPid.Calculate(error);

                DriveBase.SetRaw(output, output);

                SmartDashboard.PutNumber("Gyro PID", NavX.GetAngle());

                if (!(Math.Abs(error) < 1))
                {
                    initTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                }
                else
                {
                    if (DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond - initTime > 500)
                    {
                        break;
                    }
                }


                Thread.Sleep(20);
            }

            Console.WriteLine("Sucessfully turned");
            DriveBase.SetRaw(0 ,0);
            Console.WriteLine("End gyro: " + NavX.GetAngle());
        }

        internal static void Abort()
        {
            Console.WriteLine("Auto Aborted");
            DriveBase.SetRaw(0, 0);
        }
    }
}
