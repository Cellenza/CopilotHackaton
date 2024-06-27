

using Xunit;

namespace LifeGame
{
    public class GridTest
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenTryingToCreateAGridWithoutColumn_ExceptionIsThrown(int columnNumber)
        {
            int lineNumber = 1;
            var cell = new Cell(1, 1);

            Action action = () => Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell });

            Assert.Throws<ArgumentException>(action);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenTryingToCreateAGridWithoutLine_ExceptionIsThrown(int lineNumber)
        {
            int columnNumber = 1;
            var cell = new Cell(1, 1);

            Action action = () => Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell });

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void WhenTryingToCreateA1x1Grid_AGridWithOneColumnAndOneLineIsCreated()
        {
            int columnNumber = 1;
            int lineNumber = 1;
            var cell = new Cell(1, 1);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell });

            Assert.Equal(columnNumber, grid.NumberOfColumns);
            Assert.Equal(lineNumber, grid.NumberOfLines);
            Assert.False(grid.IsEmpty);

        }

        [Fact]
        public void WhenACellIsAliveAndHas2or3Neighbours_ItIsAliveNextRound()
        {
            int columnNumber = 2;
            int lineNumber = 2;
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2);
            var cell3 = new Cell(2, 1);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell1, cell2, cell3 });

            Grid gridNextState = grid.NextState();

            Assert.True(gridNextState.CellIsAliveAtThisPosition(1, 1));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(1, 2));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(2, 1));

        }

        [Fact]
        public void WhenACellIsAliveAndHasLessThan2Neighbours_ItIsDeadNextRound()
        {
            int columnNumber = 2;
            int lineNumber = 2;
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell1, cell2 });

            Grid gridNextState = grid.NextState();

            Assert.False(gridNextState.CellIsAliveAtThisPosition(1, 1));
            Assert.False(gridNextState.CellIsAliveAtThisPosition(1, 2));
            Assert.False(gridNextState.CellIsAliveAtThisPosition(2, 1));
            Assert.False(gridNextState.CellIsAliveAtThisPosition(2, 2));
        }

        [Fact]
        public void WhenACellIsAliveAndHasMoreThan3Neighbours_ItDiesFromOverpopulationNextRound()
        {
            int columnNumber = 2;
            int lineNumber = 3;
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(2, 1);
            var cell3 = new Cell(1, 2);
            var cell4 = new Cell(2, 2);
            var cell5 = new Cell(2, 3);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell1, cell2, cell3, cell4, cell5 });

            Grid gridNextState = grid.NextState();

            Assert.True(gridNextState.CellIsAliveAtThisPosition(cell1.ColumnPosition, cell1.LinePosition));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(cell2.ColumnPosition, cell2.LinePosition));
            Assert.False(gridNextState.CellIsAliveAtThisPosition(cell3.ColumnPosition, cell3.LinePosition));
            Assert.False(gridNextState.CellIsAliveAtThisPosition(cell4.ColumnPosition, cell4.LinePosition));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(cell5.ColumnPosition, cell5.LinePosition));

        }

        [Fact]
        public void WhenACellIsDeadAndHas3Neighbours_ItComesAliveNextRound()
        {
            int columnNumber = 2;
            int lineNumber = 2;
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(2, 1);
            var cell3 = new Cell(1, 2);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell1, cell2, cell3 });

            Grid gridNextState = grid.NextState();

            Assert.True(gridNextState.CellIsAliveAtThisPosition(cell1.ColumnPosition, cell1.LinePosition));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(cell2.ColumnPosition, cell2.LinePosition));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(cell3.ColumnPosition, cell3.LinePosition));
            Assert.True(gridNextState.CellIsAliveAtThisPosition(2, 2));
        }

        [Fact]
        public void WhenACellIsAliveAndHasLessThan3Neighbours_ItDiesFromUnderpopulationNextRound()
        {
            int columnNumber = 2;
            int lineNumber = 2;
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(2, 1);

            Grid grid = Grid.TryCreate(columnNumber, lineNumber, new List<Cell> { cell1, cell2 });

            Grid gridNextState = grid.NextState();

            Assert.False(gridNextState.CellIsAliveAtThisPosition(cell1.ColumnPosition, cell1.LinePosition));
            Assert.False(gridNextState.CellIsAliveAtThisPosition(cell2.ColumnPosition, cell2.LinePosition));
        }
    }
    
}
