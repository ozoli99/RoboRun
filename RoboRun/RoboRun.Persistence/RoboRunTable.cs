﻿namespace RoboRun.Persistence
{
    /// <summary>
    /// Type of RoboRun game table.
    /// </summary>
    public class RoboRunTable
    {
        #region Private fields

        private Robot _robot;
        private List<Wall> _walls;
        private bool[,] _fieldLocks;

        #endregion

        #region Properties

        /// <summary>
        /// Get the size of the game table.
        /// </summary>
        public int Size { get { return _fieldLocks.GetLength(0); } }
        /// <summary>
        /// Get robot.
        /// </summary>
        public Robot Robot { get { return _robot; } }
        /// <summary>
        /// Get walls.
        /// </summary>
        public IList<Wall> Walls { get { return _walls.AsReadOnly(); } }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiate RoboRunTable.
        /// </summary>
        public RoboRunTable() : this(11) { }

        /// <summary>
        /// Instantiate RoboRunTable.
        /// </summary>
        /// <param name="tableSize">Size of game table.</param>
        public RoboRunTable(int tableSize)
        {
            if (tableSize < 0)
                throw new ArgumentOutOfRangeException("The table size is less than 0.", "tableSize");

            Random random = new Random();
            int x, y;
            x = random.Next(tableSize);
            y = random.Next(tableSize);
            Array values = Enum.GetValues(typeof(Direction));
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));

            _robot = new Robot(x, y, randomDirection);
            _walls = new List<Wall>();
            _fieldLocks = new bool[tableSize, tableSize];
        }

        #endregion

        #region Public methods

        public bool HasWall(int x, int y)
        {
            // TODO: RoboRunTable.HasWall
            throw new NotImplementedException();
        }

        public bool IsLocked(int x, int y)
        {
            // TODO: RoboRunTable.IsLocked
            throw new NotImplementedException();
        }

        /// <summary>
        /// Build a wall on the game table.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        public void BuildWall(int x, int y)
        {
            if (x < 0 || x >= _fieldLocks.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldLocks.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            Wall newWall = new Wall(x, y);
            _walls.Add(newWall);
        }

        /// <summary>
        /// Lock a field on the game table.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        public void SetLock(int x, int y)
        {
            if (x < 0 || x >= _fieldLocks.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldLocks.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            _fieldLocks[x, y] = true;
        }

        #endregion
    }
}
