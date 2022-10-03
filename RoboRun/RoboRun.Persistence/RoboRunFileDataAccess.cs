namespace RoboRun.Persistence
{
    /// <summary>
    /// RoboRun file handling type.
    /// </summary>
    public class RoboRunFileDataAccess : IRoboRunDataAccess
    {
        /// <summary>
        /// Loading file.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>Game table read from file.</returns>
        public async Task<RoboRunTable> LoadAsync(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = await reader.ReadLineAsync();
                    string[] numbers = line.Split(' ');

                    int gameTime = int.Parse(numbers[0]);
                    int tableSize = int.Parse(numbers[1]);

                    RoboRunTable gameTable = new RoboRunTable(tableSize, 0, 0, Direction.Up);

                    for (int i = 0; i < tableSize; i++)
                    {
                        line = await reader.ReadLineAsync();
                        string[] locks = line.Split(' ');

                        for (int j = 0; j < tableSize; j++)
                        {
                            if (locks[j] == "1")
                            {
                                gameTable.SetLock(i, j);
                            }
                        }
                    }

                    line = await reader.ReadLineAsync();
                    string[] robotParams = line.Split(' ');
                    gameTable.Robot.X = int.Parse(robotParams[0]);
                    gameTable.Robot.Y = int.Parse(robotParams[1]);
                    gameTable.Robot.MovementDirection = (Direction)int.Parse(robotParams[2]);
                    gameTable.Robot.ReachedWall = Convert.ToBoolean(int.Parse(robotParams[3]));

                    line = await reader.ReadLineAsync();
                    numbers = line.Split(' ');
                    int wallCount = int.Parse(numbers[0]);

                    for (int i = 0; i < wallCount; i++)
                    {
                        line = await reader.ReadLineAsync();
                        string[] wallParams = line.Split(' ');

                        int x = int.Parse(wallParams[0]);
                        int y = int.Parse(wallParams[1]);
                        bool collapsed = bool.Parse(wallParams[2]);
                        Wall newWall = new Wall(x, y, collapsed);
                        
                        gameTable.Walls.Add(newWall);
                    }

                    return gameTable;
                }
            }
            catch
            {
                throw new RoboRunDataException();
            }
        }

        /// <summary>
        /// Saving file.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="gameTable">Game table for save.</param>
        /// <param name="gameTime">Game time for save.</param>
        public async Task SaveAsync(string path, RoboRunTable gameTable, int gameTime)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    await writer.WriteLineAsync(gameTime + " " + gameTable.Size);
                    
                    for (int i = 0; i < gameTable.Size; i++)
                    {
                        for (int j = 0; j < gameTable.Size; j++)
                        {
                            await writer.WriteAsync((gameTable.IsLocked(i, j) ? "1" : "0") + " ");
                        }
                        await writer.WriteLineAsync();
                    }
                    
                    await writer.WriteLineAsync(gameTable.Robot.X + " " + gameTable.Robot.Y + " " + (int)gameTable.Robot.MovementDirection + " " + (gameTable.Robot.ReachedWall ? "1" : "0"));
                    
                    await writer.WriteLineAsync(gameTable.Walls.Count + "");
                    foreach (Wall wall in gameTable.Walls)
                    {
                        await writer.WriteLineAsync(wall.X + " " + wall.Y + " " + wall.Collapsed);
                    }
                }
            }
            catch
            {
                throw new RoboRunDataException();
            }
        }
    }
}
