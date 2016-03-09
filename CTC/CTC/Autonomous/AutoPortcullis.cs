using System.Threading;
using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class AutoPortcullis
    {
        internal static void Run()
        {
            var lowerPortThread = new Thread(LowerPortRamp);

            lowerPortThread.Start();
            Arm.Lower();
            DriveBase.DriveTime(1300, -0.5);
        }

        private static void LowerPortRamp()
        {
            Portcullis.Deploy();
        }
    }
}
