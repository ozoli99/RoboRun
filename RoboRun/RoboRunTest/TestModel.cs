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
        }

        #region Public methods tests

        [TestMethod]
        public void RoboRunModelNewGameSmallTest()
        {
            _model.GameTableSize = GameTableSize.Small;

            _model.NewGame(2, 5, Direction.Down);

            Assert.AreEqual(0, _model.GameTime);
            Assert.AreEqual(7, _model.GameTable.Size);
            Assert.AreEqual(2, _model.GameTable.Robot.X);
            Assert.AreEqual(5, _model.GameTable.Robot.Y);
            Assert.AreEqual(Direction.Down, _model.GameTable.Robot.MovementDirection);
            Assert.AreEqual(0, _model.GameTable.Walls.Count);

            for (int i = 0; i < _model.GameTable.Size; i++)
            {
                for (int j = 0; j < _model.GameTable.Size; j++)
                {
                    Assert.AreEqual(false, _model.GameTable.IsLocked(i, j));
                    Assert.AreEqual(false, _model.GameTable.HasWall(i, j));

                    if (i == _model.GameTable.Size / 2 && j == _model.GameTable.Size / 2)
                    {
                        Assert.AreEqual(true, _model.GameTable.IsHome(i, j));
                    }
                    if (i == _model.GameTable.Robot.X && j == _model.GameTable.Robot.Y)
                    {
                        Assert.AreEqual(true, _model.GameTable.IsRobot(i, j));
                    }
                }
            }
        }

        [TestMethod]
        public void RoboRunModelNewGameMediumTest()
        {
            _model.GameTableSize = GameTableSize.Medium;

            _model.NewGame(2, 5, Direction.Down);

            Assert.AreEqual(0, _model.GameTime);
            Assert.AreEqual(11, _model.GameTable.Size);
            Assert.AreEqual(2, _model.GameTable.Robot.X);
            Assert.AreEqual(5, _model.GameTable.Robot.Y);
            Assert.AreEqual(Direction.Down, _model.GameTable.Robot.MovementDirection);
            Assert.AreEqual(0, _model.GameTable.Walls.Count);

            for (int i = 0; i < _model.GameTable.Size; i++)
            {
                for (int j = 0; j < _model.GameTable.Size; j++)
                {
                    Assert.AreEqual(false, _model.GameTable.IsLocked(i, j));
                    Assert.AreEqual(false, _model.GameTable.HasWall(i, j));

                    if (i == _model.GameTable.Size / 2 && j == _model.GameTable.Size / 2)
                    {
                        Assert.AreEqual(true, _model.GameTable.IsHome(i, j));
                    }
                    if (i == _model.GameTable.Robot.X && j == _model.GameTable.Robot.Y)
                    {
                        Assert.AreEqual(true, _model.GameTable.IsRobot(i, j));
                    }
                }
            }
        }

        [TestMethod]
        public void RoboRunModelNewGameBigTest()
        {
            _model.GameTableSize = GameTableSize.Big;

            _model.NewGame(2, 5, Direction.Down);

            Assert.AreEqual(0, _model.GameTime);
            Assert.AreEqual(15, _model.GameTable.Size);
            Assert.AreEqual(2, _model.GameTable.Robot.X);
            Assert.AreEqual(5, _model.GameTable.Robot.Y);
            Assert.AreEqual(Direction.Down, _model.GameTable.Robot.MovementDirection);
            Assert.AreEqual(0, _model.GameTable.Walls.Count);

            for (int i = 0; i < _model.GameTable.Size; i++)
            {
                for (int j = 0; j < _model.GameTable.Size; j++)
                {
                    Assert.AreEqual(false, _model.GameTable.IsLocked(i, j));
                    Assert.AreEqual(false, _model.GameTable.HasWall(i, j));

                    if (i == _model.GameTable.Size / 2 && j == _model.GameTable.Size / 2)
                    {
                        Assert.AreEqual(true, _model.GameTable.IsHome(i, j));
                    }
                    if (i == _model.GameTable.Robot.X && j == _model.GameTable.Robot.Y)
                    {
                        Assert.AreEqual(true, _model.GameTable.IsRobot(i, j));
                    }
                }
            }
        }

        [TestMethod]
        public void RoboRunModelStepTest()
        {
            _model.Step(2, 8);

            Assert.AreEqual(1, _model.GameTable.Walls.Count);
            Assert.AreEqual(true, _model.GameTable.IsLocked(2, 8));
        }

        [TestMethod]
        public void RoboRunModelAdvanceTimeTest()
        {
            _model.NewGame(2, 5, Direction.Down);

            Assert.AreEqual(0, _model.GameTime);
        }

        #endregion

        #region Event tests

        private void Model_GameTimeAdvanced(object sender, RoboRunEventArgs e)
        {
            Assert.IsTrue(_model.GameTime >= 0);

            Assert.AreEqual(e.ElapsedTime, _model.GameTime);
        }

        private void Model_GameTimePaused(object sender, RoboRunEventArgs e)
        {
            Assert.IsTrue(_model.GameTime >= 0);

            Assert.AreEqual(e.ElapsedTime, _model.GameTime);
        }

        private void Model_GameWin(object sender, RoboRunEventArgs e)
        {
            Assert.IsTrue(_model.IsGameWin);
            Assert.AreEqual(e.ElapsedTime, _model.GameTime);
            Assert.AreEqual(_model.GameTable.Robot.X, _model.GameTable.Size / 2);
            Assert.AreEqual(_model.GameTable.Robot.Y, _model.GameTable.Size / 2);
        }

        #endregion

        #region Async methods tests

        [TestMethod]
        public async Task RoboRunModelLoadTest()
        {
            _model.NewGame(2, 8, Direction.Down);

            await _model.LoadGameAsync(string.Empty);

            for (int i = 0; i < _model.GameTable.Size; i++)
            {
                for (int j = 0; j < _model.GameTable.Size; j++)
                {
                    Assert.AreEqual(_mockedTable.IsLocked(i, j), _model.GameTable.IsLocked(i, j));
                    Assert.AreEqual(_mockedTable.HasWall(i, j), _model.GameTable.HasWall(i, j));

                    if (i == _model.GameTable.Size / 2 && j == _model.GameTable.Size / 2)
                    {
                        Assert.AreEqual(_mockedTable.IsHome(i, j), _model.GameTable.IsHome(i, j));
                    }
                    if (i == _model.GameTable.Robot.X && j == _model.GameTable.Robot.Y)
                    {
                        Assert.AreEqual(_mockedTable.IsRobot(i, j), _model.GameTable.IsRobot(i, j));
                    }
                }
            }

            _mock.Verify(dataAccess => dataAccess.LoadAsync(string.Empty), Times.Once());
        }

        #endregion
    }
}