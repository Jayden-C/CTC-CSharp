using System;
using System.Threading;
using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class TestAuto
    {
        internal static void Run()
        {
            
        }

        internal static void Abort()
        {
            Console.WriteLine("Auto Aborted");
            DriveBase.DriveTime(1, 0);
        }
    }
}
