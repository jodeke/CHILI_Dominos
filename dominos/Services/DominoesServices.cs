using dominos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominos.Services
{
    public class DominoesServices : IDominoesServices
    {
        public bool CanAChainBeMade(IList<Tile> chosenTiles)
        {
            if (chosenTiles.Count == 0)
            {
                Console.WriteLine("can a chain exist if no tiles exist?");

                return false;
            }

            if (chosenTiles.Count == 1)
            {
                Console.WriteLine("can a chain be considered a chain if only one link is present?");

                return false;
            }

            var numberCount = new Dictionary<int, int>();
            foreach (var tile in chosenTiles)
            {
                if (!numberCount.TryAdd(tile.FirstNumber, 1))
                    numberCount[tile.FirstNumber]++;
                if (!numberCount.TryAdd(tile.SecondNumber, 1))
                    numberCount[tile.SecondNumber]++;
            }

            foreach (var count in numberCount)
            {
                if (count.Value % 2 != 0)
                {
                    Console.WriteLine("A chain cannot be made with the chosen tiles");
                    return false;
                }
            }
            Console.WriteLine("A chain CAN be made with the chosen tiles");
            return true;
        }

        public IList<Tile> TryCreateCircularChain(IList<Tile> chosenTiles)
        {
            if (chosenTiles.Count == 0)
            {
                Console.WriteLine("Similar to how a pizza can't exist without its ingredients, a chain cannot exist without its tiles");

                return [];
            }
            if (chosenTiles.Count == 1)
            {
                Console.WriteLine("Similar to how a pizza is not a pizza just because it has the base, a chain cannot exist if only one tile is present.");

                return [];
            }
            IList<Tile> chain = new List<Tile>();
            IList<Tile> chainingTiles = new List<Tile>(chosenTiles);
            Random random = new Random();
            var baseTile = chainingTiles[random.Next(chainingTiles.Count)];
            chainingTiles.Remove(baseTile);
            chain.Add(baseTile);
            Console.WriteLine("Base tile:");
            Console.WriteLine(baseTile.Base);

            bool tileAdded = true;
            while (tileAdded)
            {
                tileAdded = false;
                var firstTileOfChain = chain.First();
                var lastTileOfChain = chain.Last();
                var nextTile = chainingTiles.FirstOrDefault(tile => lastTileOfChain.SecondNumber == tile.FirstNumber || lastTileOfChain.SecondNumber == tile.SecondNumber);
                var previousTile = chainingTiles.FirstOrDefault(tile => firstTileOfChain.FirstNumber == tile.FirstNumber || firstTileOfChain.FirstNumber == tile.SecondNumber);
                if (nextTile is not null)
                {
                    if (nextTile.FirstNumber != lastTileOfChain.SecondNumber) nextTile.FlipTile();
                    tileAdded = true;
                    chainingTiles.Remove(nextTile);
                    chain.Add(nextTile);
                }
                else if (previousTile is not null)
                {
                    if (firstTileOfChain.FirstNumber != previousTile.SecondNumber) previousTile.FlipTile();
                    tileAdded = true;
                    chainingTiles.Remove(previousTile);
                    chain.Insert(0, previousTile);
                }
            }

            //check if last tile can be connected to the first tile
            if (chain.Count == chosenTiles.Count && chain.First().FirstNumber == chain.Last().SecondNumber || chain.First().FirstNumber == chain.Last().FirstNumber)
            {
                Console.WriteLine("A circular chain was created");
            }
            else
            {
                Console.WriteLine("A circular chain could not be created, let's try again");
                DisplayChain(chain);
                chain = TryCreateCircularChain(chosenTiles);
            }
            return chain;

        }
       
        public IList<Tile> PickRandomTiles(IList<Tile> tiles)
        {
            var chosenTiles = new List<Tile>();
            int rInt = Random.Shared.Next(tiles.Count);
            //pick rInt number of tiles
            for (int i = 0; i < rInt; i++)
            {
                chosenTiles.Add(tiles[Random.Shared.Next(tiles.Count)]);
            }
            return chosenTiles;
        }

        public void GenerateTiles(IList<Tile> tiles)
        {
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    tiles.Add(new Tile(i, j));
                }
            }
        }

        public void DisplayChain(IList<Tile> result)
        {
            Console.WriteLine("Chain:");
            foreach (var tile in result)
            {
                Console.WriteLine(tile.Base);
            }
        }
    }
    public interface IDominoesServices
        {
            bool CanAChainBeMade(IList<Tile> chosenTiles);
            IList<Tile> TryCreateCircularChain(IList<Tile> chosenTiles);
            IList<Tile> PickRandomTiles(IList<Tile> tiles);
            void GenerateTiles(IList<Tile> tiles);
            void DisplayChain(IList<Tile> result);
        }
    
}
