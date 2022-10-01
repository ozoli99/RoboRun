namespace RoboRun.Persistence
{
    public class RoboRunFileDataAccess : IRoboRunDataAccess
    {
        public async Task<RoboRunTable> LoadAsync(string path)
        {
            // TODO: RoboRunFileDataAccess.LoadAsync
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = await reader.ReadLineAsync();
                    string[] numbers = line.Split(' ');
                    int tableSize = int.Parse(numbers[0]);
                    RoboRunTable gameTable = new RoboRunTable(tableSize);
                    return gameTable;
                }
            }
            catch
            {
                throw new RoboRunDataException();
            }
        }

        public Task SaveAsync(string path, RoboRunTable gameTable, int gameTime)
        {
            // TODO: RoboRunFileDataAccess.SaveAsync
            throw new NotImplementedException();
        }
    }
}
