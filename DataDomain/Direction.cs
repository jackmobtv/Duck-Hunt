namespace DataDomain
{
    public class Direction
    {
        // Attributes
        public static Random random { get; } = new Random();
        public static int[] HorizontalDirections { get; } = new int[] { -6, -5, -4, -3, 0, 3, 4, 5, 6 };
        public static int[] VerticalDirections { get; } = new int[] { 2, 3, 4, 5, 6 };
    }
}