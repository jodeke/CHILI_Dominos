using dominos.Domain;
using dominos.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dominos
{
    class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDominoesServices, DominoesServices>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IDominoesServices>();

            IList<Tile> Tiles = [];
            service.GenerateTiles(Tiles);
            var chosenTiles = service.PickRandomTiles(Tiles);
            Console.WriteLine($"Chosen Tiles({chosenTiles.Count}):");
            foreach (var tile in chosenTiles)
            {
                Console.WriteLine(tile.Base);
            }
            if (service.CanAChainBeMade(chosenTiles))
            {
               var result = service.TryCreateCircularChain(chosenTiles);
                service.DisplayChain(result);
            }
            
            Console.ReadLine();
        }

    }

  

}
