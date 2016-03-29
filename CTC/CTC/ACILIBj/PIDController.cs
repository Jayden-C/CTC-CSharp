using System;
using System.Security.Cryptography;
using WPILib;

namespace ACILIBj
{
    class PIDController
    {
        private double P, I, D;

        private double _errorSum, _lastError;

        private long _lastTime;

        public bool ZeroOnCross { get; set; }
        public double IntegralLimit { get; set; }
        public double Epsilon { get; set; }

        public PIDController(double kP, double kI, double kD, double integralLimit, bool zeroOnCross)
        {
            P = kP;
            I = kI;
            D = kD;

            IntegralLimit = integralLimit;
        }

        public void Reset()
        {
            _errorSum = 0;
            _lastError = 0;
        }

        public double Calculate(double error)
        {
            var dTime = (DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond - _lastTime)/10.0;
            _lastTime = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;

            var changeInError = dTime != 0 ? (error - _lastError) / dTime : 0;

            _errorSum = Math.Abs(error) > Epsilon ? _errorSum + error*dTime : 0;
            _errorSum = Utilities.Clamp(_errorSum, IntegralLimit);

            if (ZeroOnCross)
            {
                if (Math.Sign(error) != Math.Sign(_lastError)) _errorSum = 0;
            }

            _lastError = error;

            Console.WriteLine("P: " + P*error);
            Console.WriteLine("I: " + I*_errorSum);
            Console.WriteLine("D: " + D*changeInError);

            return P*error + I*_errorSum + D*changeInError;
        }
    }
}
