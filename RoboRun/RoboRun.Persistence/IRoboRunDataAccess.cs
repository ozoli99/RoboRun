namespace RoboRun.Persistence
{
    public interface IRoboRunDataAccess
    {
        RoboRunTable Load(string path);
        void Save(string path, RoboRunTable gameTable, int gameTime);
    }
}