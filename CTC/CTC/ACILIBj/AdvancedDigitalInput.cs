using WPILib;

namespace CTC.ACILIBj
{
    class AdvancedDigitalInput
    {
        private readonly DigitalInput _input;

        private bool Inverted { get; }

        public AdvancedDigitalInput(int port, bool inverted)
        {
            _input = new DigitalInput(port);
            Inverted = inverted;
        }

        /// <summary>
        /// Returns the state of the input and inverts it if inversion is set to true
        /// </summary>
        /// <returns>State of the input</returns>
        public bool Get()
        {
            return _input.Get() ^ Inverted;
        }
    }
}
