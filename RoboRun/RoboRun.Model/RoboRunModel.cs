using RoboRun.Persistence;

namespace RoboRun.Model
{
    /// <summary>
    /// Type of RoboRun game.
    /// </summary>
    public class RoboRunModel
    {
        #region Private fields

        private IRoboRunDataAccess _dataAccess; // persistence
        private RoboRunTable _gameTable;
        private int _gameTime;

        #endregion

        #region Properties

        public RoboRunTable GameTable { get { return _gameTable; } }
        public int GameTime { get { return _gameTime; } }
        public bool IsGameOver { get { return GameTable.Robot.ReachedHome; } }

        #endregion

        #region Events

        public event EventHandler? GameOver;
        public event EventHandler? GameAdvanced;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate RoboRunModel.
        /// </summary>
        /// <param name="dataAccess">Persistence.</param>
        public RoboRunModel(IRoboRunDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _gameTable = new RoboRunTable();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Start new game.
        /// </summary>
        public void NewGame()
        {
            _gameTable = new RoboRunTable();
        }

        /// <summary>
        /// Execute step on game table.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        public void Step(int x, int y)
        {
            if (IsGameOver)
                return;
            if (GameTable.IsLocked(x, y))
                return;
            if (GameTable.Robot.X == x && GameTable.Robot.Y == y)
                return;

            GameTable.BuildWall(x, y);
            GameTable.SetLock(x, y);

            GameAdvanced?.Invoke(this, new EventArgs());
        }

        public void LoadGame(string path)
        {
            // TODO: RoboRunModel.LoadGame
            throw new NotImplementedException();
        }

        public void SaveGame(string path)
        {
            // TODO: RoboRunModel.SaveGame
            throw new NotImplementedException();
        }

        #endregion
    }
}