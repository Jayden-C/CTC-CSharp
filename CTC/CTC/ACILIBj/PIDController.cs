using System;

namespace ACILIBj
{
    class PIDController
    {
        private readonly double P, I, D;

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
            ZeroOnCross = zeroOnCross;
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

            if (ZeroOnCross)
            {
                if (Math.Sign(error) != Math.Sign(_lastError)) _errorSum = 0;
            }

            var output = P*error + D*changeInError;

            if (Math.Abs(output) < 1.0)
            {
                _errorSum = Math.Abs(error) > Epsilon ? _errorSum + error * dTime : 0;
            }
            _errorSum = Utilities.Clamp(_errorSum, IntegralLimit);

            output += I*_errorSum;

            _lastError = error;

            Console.WriteLine("P: " + P*error);
            Console.WriteLine("I: " + I*_errorSum);
            Console.WriteLine("D: " + D*changeInError);

            return output;
        }
    }
}
