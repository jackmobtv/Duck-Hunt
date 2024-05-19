using DataDomain;

namespace LogicLayer
{
    public class AssetMovement
    {
        // instantiates the Direction class
        private static readonly Direction _dir = new Direction();

        // sets the horizontal location of the duck at the start of a cycle
        public static int StartDuckPos()
        {
            int Pos = _dir.RandomClass.Next(100, 400);
            return Pos;
        }
        // get new directions for the ducks
        public static int GetNewHDirection()
        {
            int HDir;

            int randomNumberH = _dir.RandomClass.Next(0, _dir.Horizontal.Length);
            HDir = _dir.Horizontal[randomNumberH];

            return HDir;
        }

        public static int GetNewVDirection()
        {
            int VDir;

            int randomNumberV = _dir.RandomClass.Next(0, _dir.Vertical.Length);
            VDir = _dir.Vertical[randomNumberV];

            return VDir;
        }
        
        // gets the next animation depending on the way the duck is moving
        public static String GetAnimationDuck(int duckH, int duckV)
        {
            String sprite = "";

            switch (duckH)
            {
                case -6:
                case -5:
                case -4:
                case -3:
                case -2:
                    sprite = "left";
                    break;
                case 6:
                case 5:
                case 4:
                case 3:
                case 2:
                    sprite = "right";
                    break;
                case 0:
                    return "up";
            }

            switch (duckV)
            {
                case 6:
                case 5:
                case 4:
                case 3:
                    return "up" + sprite;
                case 2:
                default:
                    return sprite;
            }
        }
    }
}