using Xunit;

namespace LifeGame
{
    public class GameTest
    {
        [Fact]
        public void GivenAnGridWithAllCellsDead_TheGameIsFinishedAfterThFirstRound()
        {

            var grid = Grid.TryCreate(1, 1, new List<Cell> { });
            var game = new Game(grid);

            game.Run();

            Assert.True(game.IsFinished);
        }

        [Fact]
        public void GivenInitialState_ThenNotFinished()
        {
            var grid = Grid.TryCreate(1, 1, new List<Cell> { });
            var game = new Game(grid);

            Assert.False(game.IsFinished);

        }

        [Fact]
        public void GivenA1xA1GridWith1Cell_GameIsNotFinishedAfterOneRound()
        {
            var cell = new Cell(1,1);
            var grid = Grid.TryCreate(1, 1, new List<Cell> { cell });

            var game = new Game(grid);

            game.Run();

            Assert.False(game.IsFinished);
        }

        [Fact]
        public void GivenA1xA1GridWithCell_GameIsFinishedAfterTwoRounds()
        {
            var cell = new Cell(1,1);
            var grid = Grid.TryCreate(1, 1, new List<Cell> { cell });

            var game = new Game(grid);

            game.Run();
            game.Run();

            Assert.True(game.IsFinished);
        }



        [Fact]
        public void GivenA2xA2GridWith2Cells_GameIsFinishedAfterTwoRounds()
        {
            var cell1 = new Cell(1,1);
            var cell2 = new Cell(1,1);
            var grid = Grid.TryCreate(2, 2, new List<Cell> { cell1,cell2 });

            var game = new Game(grid);
            game.Run();
            game.Run();
            Assert.True(game.IsFinished);

        }

        [Fact]
        public void GivenA2xA2GridWith3Cells_GameIsFinishedAfterTwoRounds()
        {
            var cell1 = new Cell(1,1);
            var cell2 = new Cell(1,2);
            var cell3 = new Cell(2,1);
            var grid = Grid.TryCreate(2, 2, new List<Cell> { cell1, cell2, cell3 });

            var game = new Game(grid);
            game.Run();
            game.Run();
            Assert.True(game.IsFinished);
            Assert.False(game.GridIsEmpty());

        }


        [Fact]
        public void GivenABlockInA4x4Grid_GameIsFinishedAfterOneRound()
        {
            // Arrange
            var cell1 = new Cell(2, 2);
            var cell2 = new Cell(2, 3);
            var cell3 = new Cell(3, 2);
            var cell4 = new Cell(3, 3);
            var grid = Grid.TryCreate(4, 4, new List<Cell> { cell1, cell2, cell3, cell4 });
            var game = new Game(grid);

            // Act
            game.Run();

            // Assert
            Assert.True(game.IsFinished);
        }

        [Fact]
        public void Given3CellsInA2x3Grid_GameIsNotFinishedAfterOneRound()
        {
            // Arrange
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(2, 2);
            var cell3 = new Cell(1, 3);
            var grid = Grid.TryCreate(2, 3, new List<Cell> { cell1, cell2, cell3 });
            var game = new Game(grid);

            // Act
            game.Run();

            // Assert
            Assert.False(game.IsFinished);
        }


        [Fact]
        public void Given6CellsInA4x3Grid_GameIsNotFinishedAfterOneRound()
        {
            // Arrange
            var cell1 = new Cell(2, 1);
            var cell2 = new Cell(3, 1);
            var cell3 = new Cell(2, 2);
            var cell4 = new Cell(3, 2);
            var cell5 = new Cell(2, 3);
            var cell6 = new Cell(3, 3);
            var grid = Grid.TryCreate(4, 3, new List<Cell> { cell1, cell2, cell3, cell4, cell5, cell6 });
            var game = new Game(grid);

            // Act
            game.Run();

            // Assert
            Assert.False(game.IsFinished);

        }
    }
}