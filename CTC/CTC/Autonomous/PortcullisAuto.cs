using System;
using System.Threading;
using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class PortcullisAuto
    {
        private static readonly Thread PortThread = new Thread(Portcullis.Deploy);

        internal static void Run()
        {
            PortThread.Start();
            DriveBase.DriveTime(1300, -0.35);
            Arm.Lower();
            DriveBase.DriveTime(2100, -0.6);
            DriveBase.DriveTime(500, 0.35);
        }

        internal static void Abort()
        {
            Console.WriteLine("Auto aborted");
            PortThread.Abort();
            Portcullis.Set(0);
            Arm.SetArm(0);
            DriveBase.DriveTime(1, 0);
        }

    }
}