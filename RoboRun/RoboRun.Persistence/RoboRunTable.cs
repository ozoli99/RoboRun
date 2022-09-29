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

        #region Constructor

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
    }
}
