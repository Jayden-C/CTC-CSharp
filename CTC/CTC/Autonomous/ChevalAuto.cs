using CTC.Subsystems;

namespace CTC.Autonomous
{
    internal static class ChevalAuto
    {
        internal static void Run()
        {
            Arm.Lower(true);
            DriveBase.DriveTime(1000, 0.4);   
        }
    }
}
