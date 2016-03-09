using System.Threading;
using WPILib.SmartDashboard;

namespace CTC.Autonomous
{
    internal class AutoChooser
    {
        private static readonly SendableChooser Chooser = new SendableChooser();

        private enum Autos
        {
            Default, Portculiis, Cheval, LowBar
        }

        public AutoChooser()
        {
            Chooser.AddDefault("Default", Autos.Default);
            Chooser.AddObject("Portcullis", Autos.Portculiis);
            Chooser.AddObject("Cheval de Frise", Autos.Cheval);
            Chooser.AddObject("Low Bar", Autos.LowBar);
        }

        internal void PutData()
        {
            SmartDashboard.PutData("Auto Choices", Chooser);
        }

        internal void Run()
        {
            var autoThread = new Thread(AutoSwitch);
            autoThread.Start();
            autoThread.Join();
        }

        private static void AutoSwitch()
        {
            switch ((Autos)Chooser.GetSelected())
            {
                case Autos.Default:
                    break;
                case Autos.Portculiis:
                    AutoPortcullis.Run();
                    break;
                case Autos.Cheval:
                    AutoCheval.Run();
                    break;
                case Autos.LowBar:
                    AutoLowBar.Run();
                    break;
            }
        }
    }
}
