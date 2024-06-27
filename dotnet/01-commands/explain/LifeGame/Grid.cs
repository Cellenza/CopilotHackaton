
using System.Collections.Generic;

namespace LifeGame
{
    internal class Grid
    {

        public int NumberOfColumns { get; }
        public int NumberOfLines { get; }
        private Cell[,] Cells { get; }
        public bool IsEmpty => Cells == null || Cells.Cast<Cell>().Count(cell => cell != null) == 0;
        public bool IsFull => Cells.Cast<Cell>().Select(cell => cell != null).Count() == NumberOfColumns * NumberOfLines; 

        private Grid(int numberOfColumns, int numberOfLines, List<Cell> cellsList)
        {
            NumberOfColumns = numberOfColumns;
            NumberOfLines = numberOfLines;
            Cells = new Cell [numberOfColumns, numberOfLines];
            foreach (Cell cell in cellsList)
            {
                Cells[cell.ColumnPosition - 1, cell.LinePosition - 1] = cell;
            }
        }

        internal static Grid TryCreate(int columnNumber, int lineNumber, List<Cell> cells)
        {
            if (columnNumber <= 0 || lineNumber <= 0)
            {
                throw new ArgumentException();
            }
            return new Grid(columnNumber, lineNumber, cells);
        }

        internal bool IsEqual(Grid grid)
        {
            for (int i = 0; i < NumberOfColumns; i++)
            {
                for (int j = 0; j < NumberOfLines; j++)
                {
                    if (this.Cells[i, j] == null && grid.Cells[i, j] != null 
                        || this.Cells[i, j] != null && grid.Cells[i, j] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        internal Grid NextState()
        {
            if (IsEmpty)
                return this;
            
            List<Cell> nextCells = new List<Cell>();

            for(int columnCount = 1; columnCount <= NumberOfColumns; columnCount++)
                for(int lineCount = 1; lineCount <= NumberOfLines; lineCount++)
                {
                    int numberOfNeighbours = this.GetNumberOfNeighbours(columnCount, lineCount);

                    if (this.IsInSurvival(numberOfNeighbours, columnCount, lineCount))
                    {
                        nextCells.Add(new Cell(columnCount, lineCount));
                    }
                    else if (this.IsInReproduction(numberOfNeighbours, columnCount, lineCount))
                    {
                        nextCells.Add(new Cell(columnCount, lineCount));
                    }
                }

            return new Grid(NumberOfColumns, NumberOfLines, nextCells);
        }

        private bool IsInOverPopulation(int numberOfNeighbours)
        {
            return numberOfNeighbours > 3;
        }

        private bool IsInUnderPopulation(int numberOfNeighbours)
        {
            return numberOfNeighbours < 2;
        }

        private bool IsInSurvival(int numberOfNeighbours, int columnCount, int lineCount)
        {
            if (!CellIsAliveAtThisPosition(columnCount, lineCount))
                return false;
            
            return !(this.IsInOverPopulation(numberOfNeighbours) || this.IsInUnderPopulation(numberOfNeighbours));
        }
        private bool IsInReproduction(int numberOfNeighbours, int columnCount, int lineCount)
        {
            if (CellIsAliveAtThisPosition(columnCount, lineCount))
                return false;

            return numberOfNeighbours == 3;
        }

        internal bool CellIsAliveAtThisPosition(int columnPosition, int linePosition)
        {
            return Cells[columnPosition -1, linePosition - 1] != null;
        }
        private int GetNumberOfNeighbours(int columnPosition, int linePosition)
        {
            var neighboursCount = 0;
            for (int i = columnPosition - 1; i <= columnPosition + 1; i++)
            {
                for (int j = linePosition - 1; j <= linePosition + 1; j++)
                {
                    if (i == columnPosition && j == linePosition)
                        continue;

                    if (IsNeighbourCell(i, j) && Cells[i - 1, j - 1] != null)
                        neighboursCount++;
                }
            }
            return neighboursCount;
        }

        private bool IsNeighbourCell(int columnPosition, int linePosition)
        {
            return columnPosition >= 1 && columnPosition <= NumberOfColumns
                && linePosition >= 1 && linePosition <= NumberOfLines;
        }

    }
}