namespace RoboRun.Model
{
    /// <summary>
    /// Type of RoboRun event argument.
    /// </summary>
    public class RoboRunEventArgs : EventArgs
    {
        #region Private fields

        private int _elapsedTime;

        #endregion

        #region Properties

        /// <summary>
        /// Get elapsed game time.
        /// </summary>
        public int ElapsedTime { get { return _elapsedTime; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate RoboRun event argument.
        /// </summary>
        /// <param name="elapsedTime"></param>
        public RoboRunEventArgs(int elapsedTime)
        {
            _elapsedTime = elapsedTime;
        }

        #endregion
    }
}
