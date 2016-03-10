using System.Threading;
using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class PortcullisAuto
    {
        internal static void Run()
        {
            Portcullis.Deploy(false);
            Arm.Lower(true);
            DriveBase.DriveTime(1300, -0.5);
        }

    }
}