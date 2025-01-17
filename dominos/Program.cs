﻿using dominos.Domain;
using dominos.Services;
using dominos.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace dominos
{
    class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDominoesService, DominoesService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IDominoesService>();

            IList<Tile> tiles = [];
            service.GenerateTiles(tiles);
            var chosenTiles = service.PickRandomTiles(tiles);
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
