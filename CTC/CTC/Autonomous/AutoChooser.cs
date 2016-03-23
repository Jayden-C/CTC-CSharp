using System;
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
            Default, Portculiis, Cheval, LowBar, Drive, LowGoal, Test
        }

        public AutoChooser()
        {
            Chooser.AddDefault("Default", Autos.Default);
            Chooser.AddObject("Portcullis", Autos.Portculiis);
            Chooser.AddObject("Cheval de Frise", Autos.Cheval);
            Chooser.AddObject("Low Bar", Autos.LowBar);
            Chooser.AddObject("Drive Only", Autos.Drive);
            Chooser.AddObject("Test Auto", Autos.Test);
            Chooser.AddObject("Low GOAL", Autos.LowGoal);
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
                case Autos.Drive:
                    DriveAuto.Abort();
                    break;
                case Autos.Test:
                    TestAuto.Abort();
                    break;
                case Autos.LowGoal:
                    LowGoalAuto.Abort();
                    break;
                default:
                    break;
            }

            AutoThread.Abort();
        }

        private static void AutoSwitch()
        {
            switch ((Autos) Chooser.GetSelected())
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
                case Autos.Drive:
                    DriveAuto.Run();
                    break;
                case Autos.Test:
                    TestAuto.Run();
                    break;
                case Autos.LowGoal:
                    LowGoalAuto.Run();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
