namespace StupidRobot
{
    internal class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnum F { get; set; }

        private const int TABLE_SIZE = 5;

        public void SetPosition(int x, int y, DirectionEnum f)
        {
            X = x;
            Y = y;
            F = f;
        }

        public void TurnLeft()
        {
            switch (F)
            {
                case DirectionEnum.NORTH:
                    F = DirectionEnum.WEST;
                    break;
                case DirectionEnum.WEST:
                    F = DirectionEnum.SOUTH;
                    break;
                case DirectionEnum.SOUTH:
                    F = DirectionEnum.EAST;
                    break;
                case DirectionEnum.EAST:
                    F = DirectionEnum.NORTH;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (F)
            {
                case DirectionEnum.NORTH:
                    F = DirectionEnum.EAST;
                    break;
                case DirectionEnum.EAST:
                    F = DirectionEnum.SOUTH;
                    break;
                case DirectionEnum.SOUTH:
                    F = DirectionEnum.WEST;
                    break;
                case DirectionEnum.WEST:
                    F = DirectionEnum.NORTH;
                    break;
            }
        }

        public void MoveForward()
        {
            switch (F)
            {
                case DirectionEnum.NORTH:
                    if (IsValidMove(Y + 1))
                    {
                        Y += 1;
                    }
                    break;
                case DirectionEnum.SOUTH:
                    if (IsValidMove(Y - 1))
                    {
                        Y -= 1;
                    }
                    break;
                case DirectionEnum.EAST:
                    if (IsValidMove(X + 1))
                    {
                        X += 1;
                    }
                    break;
                case DirectionEnum.WEST:
                    if (IsValidMove(X - 1))
                    {
                        X -= 1;
                    }
                    break;
            }
        }

        private static bool IsValidMove(int newLocation)
        {
            var isValid = newLocation >= 0 && newLocation <= TABLE_SIZE;
            if (!isValid)
            {
                Console.WriteLine("Careful, I don't know how to fly :(");
            }
            return isValid;
        }

        public override string ToString()
        {
            return $"{X},{Y},{F}";
        }
    }
}