using System.Threading;
using WPILib.SmartDashboard;

namespace CTC.Autonomous
{
    internal class AutoChooser
    {
        private static readonly SendableChooser Chooser = new SendableChooser();

        private static readonly Thread AutoThread = new Thread(AutoSwitch);

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
            AutoThread.Start();
        }

        internal void Abort()
        {
            switch ((Autos)Chooser.GetSelected())
            {
                case Autos.Default:
                    break;
                case Autos.Portculiis:
                    PortcullisAuto.Abort();
                    break;
                case Autos.Cheval:
                    ChevalAuto.Abort();
                    break;
                case Autos.LowBar:
                    LowBarAuto.Abort();
                    break;
            }

            AutoThread.Abort();
        }

        private static void AutoSwitch()
        {
            switch ((Autos)Chooser.GetSelected())
            {
                case Autos.Default:
                    break;
                case Autos.Portculiis:
                    PortcullisAuto.Run();
                    break;
                case Autos.Cheval:
                    ChevalAuto.Run();
                    break;
                case Autos.LowBar:
                    LowBarAuto.Run();
                    break;
            }
        }
    }
}
