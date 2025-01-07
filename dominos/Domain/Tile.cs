namespace dominos.Domain
{
    public class Tile
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set;  }

        public string Base => $"[{FirstNumber}|{SecondNumber}]";

        public Tile(int number1, int number2)
        {
            FirstNumber = number1;
            SecondNumber = number2;
        }

    }
    public static class TileExtensions
    {
        public static Tile FlipTile(this Tile tile)
        {
            var temp = tile.FirstNumber;
            tile.FirstNumber = tile.SecondNumber;
            tile.SecondNumber = temp;
            return tile;
        }
    }
}
