using RoboRun.Persistence;

namespace RoboRun.Model
{
    /// <summary>
    /// Enum type of game table size.
    /// </summary>
    public enum GameTableSize { Small, Medium, Big }

    /// <summary>
    /// Type of RoboRun game.
    /// </summary>
    public class RoboRunModel
    {
        #region Difficulty constants

        private const int GameTableSizeSmall = 7;
        private const int GameTableSizeMedium = 11;
        private const int GameTableSizeBig = 15;

        #endregion

        #region Private fields

        private IRoboRunDataAccess _dataAccess; // persistence
        private RoboRunTable _gameTable;
        private GameTableSize _gameTableSize;
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
            _gameTableSize = GameTableSize.Medium;
            _gameTable = new RoboRunTable();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Start new game.
        /// </summary>
        public void NewGame()
        {
            _gameTime = 0;

            switch (_gameTableSize)
            {
                case GameTableSize.Small:
                    _gameTable = new RoboRunTable(GameTableSizeSmall);
                    break;
                case GameTableSize.Medium:
                    _gameTable = new RoboRunTable(GameTableSizeMedium);
                    break;
                case GameTableSize.Big:
                    _gameTable = new RoboRunTable(GameTableSizeBig);
                    break;
            }
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

        public async Task LoadGameAsync(string path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _gameTable = await _dataAccess.LoadAsync(path);
        }

        public async Task SaveGameAsync(string path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _gameTable, _gameTime);
        }

        #endregion
    }
}