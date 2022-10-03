using Moq;
using RoboRun.Model;
using RoboRun.Persistence;

namespace RoboRunTest
{
    [TestClass]
    public class TestModel
    {
        private RoboRunModel _model;
        private RoboRunTable _mockedTable;
        private Mock<IRoboRunDataAccess> _mock;

        [TestInitialize]
        public void Initialize()
        {
            _mockedTable = new RoboRunTable(11, 3, 9, Direction.Up);

            _mock = new Mock<IRoboRunDataAccess>();
            _mock.Setup(mock => mock.LoadAsync(It.IsAny<string>())).Returns(() => Task.FromResult(_mockedTable));

            _model = new RoboRunModel(_mock.Object);
            _model.GameWin += new EventHandler<RoboRunEventArgs>(Model_GameWin);
            _model.GameTimeAdvanced += new EventHandler<RoboRunEventArgs>(Model_GameTimeAdvanced);
            _model.GameTimePaused += new EventHandler<RoboRunEventArgs>(Model_GameTimePaused);
            _model.RobotMoved += new EventHandler(Model_RobotMoved);
        }

        #region Load

        [TestMethod]
        public void TestLoadGame()
        {
            RoboRunTable gameTable = new RoboRunTable(11, 3, 9, Direction.Up);

            _mock.Setup(m => m.LoadAsync("path")).Returns(gameTable);
        }

        #endregion
    }
}