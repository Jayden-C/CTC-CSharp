using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class LowBarAuto
    {
        internal static void Run()
        {
            Arm.Lower(true);
            DriveBase.DriveTime(2000, -0.5);
        }
    }
}