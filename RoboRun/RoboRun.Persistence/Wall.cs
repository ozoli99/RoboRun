namespace RoboRun.Persistence
{
    /// <summary>
    /// Type of wall.
    /// </summary>
    public class Wall
    {
        #region Properties

        /// <summary>
        /// Get horizontal coordinate.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Get vertical coordinate.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Get wall collapsed.
        /// </summary>
        public bool Collapsed { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate wall.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        /// <param name="collapsed">Wall collapsed.</param>
        public Wall(int x, int y, bool collapsed = false)
        {
            X = x;
            Y = y;
            Collapsed = collapsed;
        }

        #endregion
    }
}
