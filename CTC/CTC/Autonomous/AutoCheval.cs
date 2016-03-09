using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class AutoCheval
    {
        internal static void Run()
        {
            Arm.Lower();
            DriveBase.DriveTime(1000, 0.4);   
        }
    }
}
