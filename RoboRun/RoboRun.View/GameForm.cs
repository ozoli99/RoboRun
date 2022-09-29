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

        public GameForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form event handler

        private void GameForm_Load(object? sender, EventArgs e)
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
    }
}