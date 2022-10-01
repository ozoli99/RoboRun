namespace RoboRun.Model
{
    public class RoboRunEventArgs : EventArgs
    {
        private int _elapsedTime;

        /// <summary>
        /// Get elapsed game time.
        /// </summary>
        public int ElapsedTime { get { return _elapsedTime; } }

        /// <summary>
        /// Instantiate RoboRun event argument.
        /// </summary>
        /// <param name="elapsedTime"></param>
        public RoboRunEventArgs(int elapsedTime)
        {
            _elapsedTime = elapsedTime;
        }
    }
}
