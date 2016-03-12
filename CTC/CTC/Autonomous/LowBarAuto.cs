using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class LowBarAuto
    {
        internal static void Run()
        {
            Arm.Lower();
            DriveBase.DriveTime(2000, -0.5);
        }

        internal static void Abort()
        {
            Arm.SetArm(0);
            DriveBase.DriveTime(1, 0);
        }
    }
}