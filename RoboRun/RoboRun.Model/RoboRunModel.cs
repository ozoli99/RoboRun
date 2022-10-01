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

        #endregion

        #region Events

        public event EventHandler GameOver;

        #endregion

        #region Constructor

        public RoboRunModel(IRoboRunDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _gameTable = new RoboRunTable();
        }

        #endregion

        #region Public methods

        public void NewGame()
        {
            _gameTable = new RoboRunTable();
        }

        public void Step(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void LoadGame(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(string path)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}