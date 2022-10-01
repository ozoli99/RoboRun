namespace RoboRun.Persistence
{
    public enum Direction { Up, Down, Left, Right }

    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool ReachedHome { get; set; }
        public bool ReachedWall { get; set; }
        public Direction MovementDirection { get; set; }

        public Robot(int x, int y, Direction movementDirection, bool reachedHome = false, bool reachedWall = false)
        {
            X = x;
            Y = y;
            MovementDirection = movementDirection;
            ReachedHome = reachedHome;
            ReachedWall = reachedWall;
        }
    }
}
