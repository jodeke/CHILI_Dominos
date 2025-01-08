namespace dominos.Domain
{
    public class Tile
    {
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }

        public string Base => $"[{FirstNumber}|{SecondNumber}]";

        public Tile(int firstNumber, int secondNumber)
        {
            SetFirstNumber(firstNumber);
            SetSecondNumber(secondNumber);
        }

        public Tile SetFirstNumber(int firstNumber)
        {
            FirstNumber = firstNumber;
            return this;
        }

        public Tile SetSecondNumber(int secondNumber)
        {
            SecondNumber = secondNumber;
            return this;
        }

    }
    public static class TileExtensions
    {
        public static Tile FlipTile(this Tile tile)
        {
            var firstNumber = tile.FirstNumber;
            tile.SetFirstNumber(tile.SecondNumber)
                .SetSecondNumber(firstNumber);
            return tile;
        }
    }
}
