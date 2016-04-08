using System;
using System.Threading;
using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class ChevalAuto
    {
        private static readonly Thread PortRetract = new Thread(Portcullis.Retract);

        internal static void Run()
        {
            DriveBase.DriveTime(1300, -0.35);
            Arm.Raise();
            if (!Portcullis.DeployBool()) return;
            DriveBase.DriveTime(700, -0.6);
            PortRetract.Start();
            DriveBase.DriveTime(700, -0.8);
            Thread.Sleep(700);
            DriveBase.DriveTime(1000, -0.35);
            DriveBase.DriveTime(500, 0.35);
        }

        internal static void Abort()
        {
            Console.WriteLine("Auto aborted");
            PortRetract.Abort();
            Portcullis.Set(0);
            DriveBase.DriveTime(1, 0);
        }
    }
}