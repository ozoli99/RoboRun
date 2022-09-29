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
    }
}