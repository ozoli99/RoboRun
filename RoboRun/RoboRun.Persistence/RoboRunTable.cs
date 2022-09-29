namespace RoboRun.Persistence
{
    /// <summary>
    /// Type of RoboRun game table.
    /// </summary>
    public class RoboRunTable
    {
        #region Private fields

        private int[,] _fieldValues;
        private bool[,] _fieldLocks;

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

            _fieldValues = new int[tableSize, tableSize];
            _fieldLocks = new bool[tableSize, tableSize];
        }

        #endregion

        #region Public methods

        public bool HasWall(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool IsLocked(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void SetLock(int x, int y)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            _fieldLocks[x, y] = true;
        }

        #endregion
    }
}
