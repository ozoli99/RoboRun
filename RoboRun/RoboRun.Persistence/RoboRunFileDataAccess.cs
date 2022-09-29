namespace RoboRun.Persistence
{
    public class RoboRunFileDataAccess : IRoboRunDataAccess
    {
        public Task<RoboRunTable> LoadAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(string path, RoboRunTable gameTable, int gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
