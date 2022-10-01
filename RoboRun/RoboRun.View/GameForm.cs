using RoboRun.Model;
using RoboRun.Persistence;

namespace RoboRun.View
{
    public partial class GameForm : Form
    {
        #region Private fields

        private IRoboRunDataAccess _dataAccess; // persistence
        private RoboRunModel _model;    // game model
        private Button[,] _buttonGrid;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _robotTimer;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate GameForm.
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form event handler

        /// <summary>
        /// Event handler of loading GameForm.
        /// </summary>
        private void GameForm_Load(object? sender, EventArgs e)
        {
            // Instantiate persistence
            _dataAccess = new RoboRunFileDataAccess();

            // Create model
            _model = new RoboRunModel(_dataAccess);
            _model.GameWin += new EventHandler<RoboRunEventArgs>(Game_GameWin);
            _model.RobotMoved += new EventHandler(Game_RobotMoved);

            // Create timer for game time
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(Timer_Tick);

            // Create timer for robot movement
            _robotTimer = new System.Windows.Forms.Timer();
            _robotTimer.Interval = 500;
            _robotTimer.Tick += new EventHandler(RobotTimer_Tick);

            NewGame();
        }

        #endregion

        #region Game event handlers

        private void Game_GameWin(object? sender, RoboRunEventArgs e)
        {
            _timer.Stop();
            _robotTimer.Stop();

            foreach (Button button in _buttonGrid)
            {
                button.Enabled = false;
            }

            _menuFileSaveGame.Enabled = false;

            MessageBox.Show("You Won!" + Environment.NewLine + "Time: " + TimeSpan.FromSeconds(e.ElapsedTime).ToString("g"), "RoboRun", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Game_RobotMoved(object? sender, EventArgs e)
        {
            // _buttonGrid[i, j].Location = new Point(5 + 50 * j, 35 + 50 * i);

        }

        #endregion

        #region Grid event handler

        /// <summary>
        /// Event handler of button grid.
        /// </summary>
        private void ButtonGrid_MouseClick(object? sender, MouseEventArgs e)
        {
            int x = ((sender as Button).TabIndex - 100) / _model.GameTable.Size;
            int y = ((sender as Button).TabIndex - 100) % _model.GameTable.Size;

            _model.Step(x, y);

            // TODO: Refresh field display.
        }

        #endregion

        #region Menu event handlers

        private void MenuFileNewGame_Click(object? sender, EventArgs e)
        {
            _menuFileSaveGame.Enabled = true;

            _model.NewGame();
            SetupGameTable();
            SetupMenus();

            _timer.Start();
            _robotTimer.Start();
        }

        private async void MenuFileLoadGame_Click(object? sender, EventArgs e)
        {
            bool restartTimer = _timer.Enabled;
            _timer.Stop();
            _robotTimer.Stop();

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                    _menuFileSaveGame.Enabled = true;
                }
                catch (RoboRunDataException)
                {
                    MessageBox.Show("Error occurred during load!" + Environment.NewLine + "Wrong path or file format.", "RoboRun Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _model.NewGame();
                    _menuFileSaveGame.Enabled = true;
                }

                SetupGameTable();
            }

            if (restartTimer)
            {
                _timer.Start();
                _robotTimer.Start();
            }
        }

        private async void MenuFileSaveGame_Click(object? sender, EventArgs e)
        {
            bool restartTimer = _timer.Enabled;
            _timer.Stop();
            _robotTimer.Stop();

            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (RoboRunDataException)
                {
                    MessageBox.Show("Error occurred during save!" + Environment.NewLine + "Wrong path or directory has no writing access.", "RoboRun Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (restartTimer)
            {
                _timer.Start();
                _robotTimer.Start();
            }
        }

        /// <summary>
        /// Event handler of exit the game.
        /// </summary>
        private void MenuFileExitGame_Click(object? sender, EventArgs e)
        {
            bool restartTimer = _timer.Enabled;
            _timer.Stop();
            _robotTimer.Stop();

            if (MessageBox.Show("Are you sure you want to quit?", "RoboRun", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                if (restartTimer)
                {
                    _timer.Start();
                    _robotTimer.Start();
                }
            }
        }

        private void MenuGameSmall_Click(object? sender, EventArgs e)
        {
            _model.GameTableSize = GameTableSize.Small;
            NewGame();
        }

        private void MenuGameMedium_Click(object? sender, EventArgs e)
        {
            _model.GameTableSize = GameTableSize.Medium;
            NewGame();
        }

        private void MenuGameBig_Click(object? sender, EventArgs e)
        {
            _model.GameTableSize = GameTableSize.Big;
            NewGame();
        }

        #endregion

        #region Timer event handler

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _model.AdvanceTime();
        }

        private void RobotTimer_Tick(object? sender, EventArgs e)
        {
            _model.MoveRobot();
        }

        #endregion

        #region Private meghods

        /// <summary>
        /// Start a new game.
        /// </summary>
        private void NewGame()
        {
            // Start new game
            _model.NewGame();

            // Initialize gameTable and menus
            GenerateGameTable();
            SetupGameTable();
            SetupMenus();

            // Setup window parameters
            this.Width = (_model.GameTable.Size * 50) + 26;
            this.Height = (_model.GameTable.Size * 50) + 110;

            _timer.Start();
            _robotTimer.Start();
        }

        /// <summary>
        /// Generate new game table.
        /// </summary>
        private void GenerateGameTable()
        {
            _buttonGrid = new Button[_model.GameTable.Size, _model.GameTable.Size];
            for (int i = 0; i < _model.GameTable.Size; i++)
            {
                for (int j = 0; j < _model.GameTable.Size; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + 50 * j, 35 + 50 * i);
                    _buttonGrid[i, j].Size = new Size(50, 50);
                    _buttonGrid[i, j].BackgroundImage = (Image)Resource.ResourceManager.GetObject("robot");
                    _buttonGrid[i, j].Enabled = false;
                    _buttonGrid[i, j].TabIndex = 100 + i * _model.GameTable.Size + j;
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

                    Controls.Add(_buttonGrid[i, j]);
                }
            }
        }

        /// <summary>
        /// Setup game table.
        /// </summary>
        private void SetupGameTable()
        {
            for (int i = 0; i < _buttonGrid.GetLength(0); i++)
            {
                for (int j = 0; j < _buttonGrid.GetLength(1); j++)
                {
                    if (_model.GameTable.IsLocked(i, j))
                    {
                        _buttonGrid[i, j].Enabled = false;
                        _buttonGrid[i, j].BackColor = Color.Gray;
                    }
                    else
                    {
                        _buttonGrid[i, j].Enabled = true;
                        _buttonGrid[i, j].BackColor = Color.White;
                    }

                    if (_model.GameTable.HasWall(i, j))
                    {
                        _buttonGrid[i, j].BackColor = Color.Yellow;
                    }
                    else
                    {
                        if (_model.GameTable.IsLocked(i, j))
                        {
                            _buttonGrid[i, j].Enabled = false;
                            _buttonGrid[i, j].BackColor = Color.Gray;
                        }
                        else
                        {
                            _buttonGrid[i, j].Enabled = true;
                            _buttonGrid[i, j].BackColor = Color.White;
                        }
                    }
                }
            }

            _toolLabelGameTime.Text = TimeSpan.FromSeconds(_model.GameTime).ToString("g");
        }

        /// <summary>
        /// Setup menus.
        /// </summary>
        private void SetupMenus()
        {
            _menuGameSmall.Checked = (_model.GameTableSize == GameTableSize.Small);
            _menuGameMedium.Checked = (_model.GameTableSize == GameTableSize.Medium);
            _menuGameBig.Checked = (_model.GameTableSize == GameTableSize.Big);
        }

        #endregion
    }
}