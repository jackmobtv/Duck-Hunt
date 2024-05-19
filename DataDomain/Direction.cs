namespace DataDomain
{
    public class Direction
    {
        // variables used in other classes
        private readonly Random rand;
        private readonly int[] HorizontalDirections;
        private readonly int[] VerticalDirections;

        // constructor for the class
        public Direction()
        {
            rand = new Random();
            HorizontalDirections = new int[] { -6, -5, -4, -3, 0, 3, 4, 5, 6 };
            VerticalDirections = new int[] { 2, 3, 4, 5, 6 };
        }

        public int[] Horizontal
        {
            get { return HorizontalDirections; }
        }

        public int[] Vertical
        {
            get { return VerticalDirections; }
        }

        public Random RandomClass
        {
            get { return rand; }
        }
    }
}