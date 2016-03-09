using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class AutoLowBar
    {
        internal static void Run()
        {
            Arm.Lower();
            DriveBase.DriveTime(2000, -0.5);
        }
    }
}
