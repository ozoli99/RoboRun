namespace RoboRun.Persistence
{
    public class Wall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Collapsed { get; set; }

        public Wall(int x, int y, bool collapsed)
        {
            X = x;
            Y = y;
            Collapsed = collapsed;
        }
    }
}
