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
            _model.GameOver += new EventHandler(Game_GameOver);

            // Create timer
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(Timer_Tick);

            // Initialize gameTable and menus
            GenerateGameTable();
            SetupMenus();

            // Start new game
            _model.NewGame();
            SetupGameTable();

            _timer.Start();
        }

        #endregion

        #region Game event handlers

        private void Game_GameOver(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Menu event handlers

        private void MenuFileNewGame_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuFileLoadGame_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuFileSaveGame_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuFileExitGame_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuGameSmall_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuGameMedium_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuGameBig_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Timer event handler

        private void Timer_Tick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private meghods

        private void GenerateGameTable()
        {
            throw new NotImplementedException();
        }

        private void SetupGameTable()
        {
            throw new NotImplementedException();
        }

        private void SetupMenus()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}