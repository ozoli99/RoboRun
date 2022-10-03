namespace RoboRun.Persistence
{
    /// <summary>
    /// Enum type of directions.
    /// </summary>
    public enum Direction { Up, Down, Left, Right }

    /// <summary>
    /// Type of robot.
    /// </summary>
    public class Robot
    {
        #region Properties

        public int X { get; set; }
        public int Y { get; set; }
        public bool ReachedHome { get; set; }
        public bool ReachedWall { get; set; }
        public Direction MovementDirection { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate robot.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        /// <param name="movementDirection">Direction to move.</param>
        /// <param name="reachedHome">The robot reached home.</param>
        /// <param name="reachedWall">The robot reached a wall.</param>
        public Robot(int x, int y, Direction movementDirection, bool reachedHome = false, bool reachedWall = false)
        {
            X = x;
            Y = y;
            MovementDirection = movementDirection;
            ReachedHome = reachedHome;
            ReachedWall = reachedWall;
        }

        #endregion
    }
}
