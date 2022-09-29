namespace RoboRun.Persistence
{
    /// <summary>
    /// RoboRun file handling interface.
    /// </summary>
    public interface IRoboRunDataAccess
    {
        /// <summary>
        /// Loading file.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <returns>Game table from given file.</returns>
        Task<RoboRunTable> LoadAsync(string path);

        /// <summary>
        /// Saving file.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="gameTable">Game table to write in file.</param>
        /// <param name="gameTime">Game time to write in file.</param>
        /// <returns></returns>
        Task SaveAsync(string path, RoboRunTable gameTable, int gameTime);
    }
}