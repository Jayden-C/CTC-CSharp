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

        private static int _selectedAuto;

        internal void PutData()
        {
            Chooser.AddDefault("Default", Autos.Default);
            Chooser.AddObject("Portcullis", Autos.Portculiis);
            Chooser.AddObject("Cheval de Frise", Autos.Cheval);
            Chooser.AddObject("Low Bar", Autos.LowBar);
            Chooser.AddObject("Drive Only", Autos.Drive);
            Chooser.AddObject("Test Auto", Autos.Test);
            Chooser.AddObject("Low GOAL", Autos.LowGoal);
            SmartDashboard.PutData("Auto Choices", Chooser);
        }

        internal void GetChoice(int value)
        {
            _selectedAuto = value;
        }

        internal void Run()
        {
            AutoThread.Start();
        }
        
        internal void Abort()
        {
            switch (_selectedAuto)
            {
                case (int)Autos.Default:
                    break;
                case (int)Autos.Portculiis:
                    PortcullisAuto.Abort();
                    break;
                case (int)Autos.Cheval:
                    ChevalAuto.Abort();
                    break;
                case (int)Autos.LowBar:
                    LowBarAuto.Abort();
                    break;
                case (int)Autos.Drive:
                    DriveAuto.Abort();
                    break;
                case (int)Autos.Test:
                    TestAuto.Abort();
                    break;
                case (int)Autos.LowGoal:
                    LowGoalAuto.Abort();
                    break;
            }

            AutoThread.Abort();
        }

        private static void AutoSwitch()
        {
            Console.WriteLine("AUTO SELECTED: {0}", _selectedAuto);

            switch (_selectedAuto)
            {
                case (int)Autos.Default:
                    break;
                case (int)Autos.Portculiis:
                    PortcullisAuto.Run();
                    break;
                case (int)Autos.Cheval:
                    ChevalAuto.Run();
                    break;
                case (int)Autos.LowBar:
                    LowBarAuto.Run();
                    break;
                case (int)Autos.Drive:
                    DriveAuto.Run();
                    break;
                case (int)Autos.Test:
                    TestAuto.Run();
                    break;
                case (int)Autos.LowGoal:
                    LowGoalAuto.Run();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
