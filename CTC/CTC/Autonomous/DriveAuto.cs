using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class DriveAuto
    {
        internal static void Run()
        {
            Arm.Raise();
            DriveBase.DriveTime(2000, 0.9);
        }

        internal static void Abort()
        {
            DriveBase.DriveTime(1, 0);
        }
    }
}
