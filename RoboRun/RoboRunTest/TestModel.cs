using Moq;
using RoboRun.Model;
using RoboRun.Persistence;

namespace RoboRunTest
{
    [TestClass]
    public class TestModel
    {
        private RoboRunModel _model;
        private Mock<IRoboRunDataAccess> _mock;

        public TestModel()
        {
            _mock = new Mock<IRoboRunDataAccess>();
            _model = new RoboRunModel(_mock.Object);
        }

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        #region Load

        [TestMethod]
        public void TestLoadGame()
        {
            int gameTime = 0;
            int tableSize = 0;

            RoboRunTable gameTable = new RoboRunTable(tableSize, 0, 0, Direction.Up);
            _mock.Setup(m => m.LoadAsync("path"));
        }

        #endregion
    }
}