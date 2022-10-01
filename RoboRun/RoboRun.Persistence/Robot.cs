namespace RoboRun.Persistence
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool ReachedHome { get; set; }

        public Robot(int x, int y, bool reachedHome)
        {
            X = x;
            Y = y;
            ReachedHome = reachedHome;
        }
    }
}
