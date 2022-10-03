﻿using RoboRun.Persistence;

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
        private RoboRunTable _gameTable;    // game table
        private GameTableSize _gameTableSize;   // game table size
        private int _gameTime;  // game time

        #endregion

        #region Properties

        public RoboRunTable GameTable { get { return _gameTable; } }
        public GameTableSize GameTableSize { get { return _gameTableSize; } set { _gameTableSize = value; } }
        public int GameTime { get { return _gameTime; } }
        public bool IsGameWin { get { return GameTable.Robot.ReachedHome; } }

        #endregion

        #region Events

        public event EventHandler<RoboRunEventArgs>? GameWin;
        public event EventHandler<RoboRunEventArgs>? GameTimeAdvanced;
        public event EventHandler<RoboRunEventArgs>? GameTimePaused;
        public event EventHandler? RobotMoved;

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
            _gameTable = new RoboRunTable(GameTableSizeMedium);
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
        /// Fire GameTimePaused event to freeze the game.
        /// </summary>
        public void PauseGame()
        {
            GameTimePaused?.Invoke(this, new RoboRunEventArgs(_gameTime));
        }

        /// <summary>
        /// Execute step on game table.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        public void Step(int x, int y)
        {
            if (IsGameWin)
                return;
            if (GameTable.IsLocked(x, y))
                return;
            if (GameTable.Robot.X == x && GameTable.Robot.Y == y)
                return;

            GameTable.BuildWall(x, y);
            GameTable.SetLock(x, y);
        }

        /// <summary>
        /// Increase game time.
        /// </summary>
        public void AdvanceTime()
        {
            if (IsGameWin)
                return;

            _gameTime++;
            GameTimeAdvanced?.Invoke(this, new RoboRunEventArgs(_gameTime));
        }

        /// <summary>
        /// Handle robot movement and wall collapsing.
        /// </summary>
        public void MoveRobot()
        {
            if (GameTable.Robot.ReachedWall)
            {
                GenerateRandomDirection();
            }
            else
            {
                switch (GameTable.Robot.MovementDirection)
                {
                    case Direction.Up:
                        if (GameTable.Robot.X - 1 < 0)
                        {
                            GameTable.Robot.ReachedEnd = true;
                            GenerateRandomDirection();
                        }
                        else
                        {
                            GameTable.Robot.ReachedEnd = false;

                            if (GameTable.HasWall(GameTable.Robot.X - 1, GameTable.Robot.Y))
                            {
                                if (GameTable.GetWall(GameTable.Robot.X - 1, GameTable.Robot.Y).Collapsed)
                                {
                                    GameTable.Robot.ReachedWall = false;
                                    GameTable.Robot.X -= 1;
                                }
                                else
                                {
                                    GameTable.Robot.ReachedWall = true;
                                    GameTable.GetWall(GameTable.Robot.X - 1, GameTable.Robot.Y).Collapsed = true;
                                    GenerateRandomDirection();
                                }
                            }
                            else
                            {
                                GameTable.Robot.ReachedWall = false;
                                GameTable.Robot.X -= 1;
                            }
                        }
                        break;
                    case Direction.Down:
                        if (GameTable.Robot.X >= GameTable.Size - 1)
                        {
                            GameTable.Robot.ReachedEnd = true;
                            GenerateRandomDirection();
                        }
                        else
                        {
                            GameTable.Robot.ReachedEnd = false;

                            if (GameTable.HasWall(GameTable.Robot.X + 1, GameTable.Robot.Y))
                            {
                                if (GameTable.GetWall(GameTable.Robot.X + 1, GameTable.Robot.Y).Collapsed)
                                {
                                    GameTable.Robot.ReachedWall = false;
                                    GameTable.Robot.X += 1;
                                }
                                else
                                {
                                    GameTable.Robot.ReachedWall = true;
                                    GameTable.GetWall(GameTable.Robot.X + 1, GameTable.Robot.Y).Collapsed = true;
                                    GenerateRandomDirection();
                                }
                            }
                            else
                            {
                                GameTable.Robot.ReachedWall = false;
                                GameTable.Robot.X += 1;
                            }
                        }
                        break;
                    case Direction.Left:
                        if (GameTable.Robot.Y - 1 < 0)
                        {
                            GameTable.Robot.ReachedEnd = true;
                            GenerateRandomDirection();
                        }
                        else
                        {
                            GameTable.Robot.ReachedEnd = false;

                            if (GameTable.HasWall(GameTable.Robot.X, GameTable.Robot.Y - 1))
                            {
                                if (GameTable.GetWall(GameTable.Robot.X, GameTable.Robot.Y - 1).Collapsed)
                                {
                                    GameTable.Robot.ReachedWall = false;
                                    GameTable.Robot.Y -= 1;
                                }
                                else
                                {
                                    GameTable.Robot.ReachedWall = true;
                                    GameTable.GetWall(GameTable.Robot.X, GameTable.Robot.Y - 1).Collapsed = true;
                                    GenerateRandomDirection();
                                }
                            }
                            else
                            {
                                GameTable.Robot.ReachedWall = false;
                                GameTable.Robot.Y -= 1;
                            }
                        }
                        break;
                    case Direction.Right:
                        if (GameTable.Robot.Y >= GameTable.Size - 1)
                        {
                            GameTable.Robot.ReachedEnd = true;
                            GenerateRandomDirection();
                        }
                        else
                        {
                            GameTable.Robot.ReachedEnd = false;

                            if (GameTable.HasWall(GameTable.Robot.X, GameTable.Robot.Y + 1))
                            {
                                if (GameTable.GetWall(GameTable.Robot.X, GameTable.Robot.Y + 1).Collapsed)
                                {
                                    GameTable.Robot.ReachedWall = false;
                                    GameTable.Robot.Y += 1;
                                }
                                else
                                {
                                    GameTable.Robot.ReachedWall = true;
                                    GameTable.GetWall(GameTable.Robot.X, GameTable.Robot.Y + 1).Collapsed = true;
                                    GenerateRandomDirection();
                                }
                            }
                            else
                            {
                                GameTable.Robot.ReachedWall = false;
                                GameTable.Robot.Y += 1;
                            }
                        }
                        break;
                }
            }
            CheckGame();
            RobotMoved?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Loading game.
        /// </summary>
        /// <param name="path">Path.</param>
        public async Task LoadGameAsync(string path)
        {
            // TODO: Fix game loading

            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _gameTable = await _dataAccess.LoadAsync(path);
        }

        /// <summary>
        /// Saving game.
        /// </summary>
        /// <param name="path">Path.</param>
        public async Task SaveGameAsync(string path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _gameTable, _gameTime);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Generate random direction in case of the robot reach a wall.
        /// </summary>
        private void GenerateRandomDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            while (GameTable.Robot.MovementDirection == randomDirection)
            {
                randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            }
            GameTable.Robot.MovementDirection = randomDirection;
            GameTable.Robot.ReachedWall = false;
        }

        /// <summary>
        /// Checks that the player won the game.
        /// </summary>
        private void CheckGame()
        {
            if (GameTable.Robot.X == GameTable.Size / 2 && GameTable.Robot.Y == GameTable.Size / 2)
            {
                GameWin?.Invoke(this, new RoboRunEventArgs(_gameTime));
            }
        }

        #endregion
    }
}