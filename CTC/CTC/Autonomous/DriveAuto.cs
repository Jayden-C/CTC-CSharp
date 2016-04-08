using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class DriveAuto
    {
        internal static void Run()
        {
            Arm.Raise();
            DriveBase.DriveTime(2000, 0.9);
            DriveBase.DriveTime(400, -0.5);
            DriveBase.DriveTime(1, 0);
        }

        internal static void Abort()
        {
            DriveBase.DriveTime(1, 0);
        }
    }
}
