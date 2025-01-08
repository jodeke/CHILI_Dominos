using dominos.Domain;
using dominos.Services;
using NUnit.Framework;

namespace dominos.Tests
{
    [TestFixture]
    public class DominoTests
    {
        private DominoesService dominoesServices;

        [SetUp]
        public void Init()
        {
            dominoesServices = new DominoesService();
        }
        [Test]
        public void CanAChainBeMade_WithValidTiles_ReturnsTrue()
        {
            //Arrange
            var chosenTiles = new List<Tile>
            {
                new Tile(1, 2),
                new Tile(2, 3),
                new Tile(3, 4),
                new Tile(4, 5),
                new Tile(5, 6),
                new Tile(6, 1)
            };

            //Act
            var result = dominoesServices.CanAChainBeMade(chosenTiles);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanAChainBeMade_WithInvalidTiles_ReturnsFalse()
        {
            //Arrange
            var chosenTiles = new List<Tile>
            {
                new Tile(1, 2),
                new Tile(2, 3),
                new Tile(3, 4),
                new Tile(4, 5),
                new Tile(5, 6),
                new Tile(6, 6)
            };

            //Act
            var result = dominoesServices.CanAChainBeMade(chosenTiles);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]

        public void TryCreateCircularChain_TileNumbersChainCorrectly()
        {
            //Arrange
            var chosenTiles = new List<Tile>
            {
                new (4, 5),
                new (0, 1),
                new (4, 6),
                new (5, 0),
                new (2, 3),
                new (1, 3),
                new (3, 5),
                new (1, 2),
                new (5, 6),
                new (3, 4),
                new (2, 4),
                new (1, 6),
                new (0, 2),
                new (0, 6),
            };

            //Act
            var result = dominoesServices.TryCreateCircularChain(chosenTiles);
            dominoesServices.DisplayChain(result);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(chosenTiles.Count));
            //assert that each tile's second number is equal to the next tile's first number
            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.That(result[i].SecondNumber, Is.EqualTo(result[i + 1].FirstNumber));
            }
        }

        [Test]

        public void TryCreateCircularChain_WithNoTiles_ReturnsEmptyList()
        {
            //Arrange
            var chosenTiles = new List<Tile>();

            //Act
            var result = dominoesServices.TryCreateCircularChain(chosenTiles);

            //Assert
            Assert.That(result, Is.Empty);
        }
        [Test]

        public void TryCreateCircularChain_WithOneTiles_ReturnsEmptyList()
        {
            //Arrange
            var chosenTiles = new List<Tile> {
                new (4, 5)           
            }; ;

            //Act
            var result = dominoesServices.TryCreateCircularChain(chosenTiles);

            //Assert
            Assert.That(result, Is.Empty);
        }
}
}
