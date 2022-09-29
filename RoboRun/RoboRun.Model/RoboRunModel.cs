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

        #region Constructor

        public RoboRunModel()
        {

        }

        #endregion
    }
}