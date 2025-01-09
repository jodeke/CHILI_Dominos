using dominos.Domain;

namespace dominos.Services.Interfaces
{
    public interface IDominoesService
    {
        bool CanAChainBeMade(IList<Tile> chosenTiles);
        IList<Tile> TryCreateCircularChain(IList<Tile> chosenTiles);
        IList<Tile> PickRandomTiles(IList<Tile> tiles);
        void GenerateTiles(IList<Tile> tiles);
        void DisplayChain(IList<Tile> result);
    }

}
