#include "pch.h"
#include "Grid.h"

Grid::Grid(int numberOfColumns, int numberOfLines, const std::vector<Cell>& cells)
    : _numberOfColumns(numberOfColumns), _numberOfLines(numberOfLines)
{ 
    if ((numberOfColumns <= 0) || (numberOfLines <= 0))
    {
        throw std::invalid_argument("Invalid grid size");
    }

    _cells.resize(_numberOfColumns);
    for (auto& column : _cells)
    {
        column.resize(_numberOfLines);
    }

    for (const auto& cell : cells)
    {
        _cells[cell.ColumnPosition() - 1][cell.LinePosition() - 1] = cell;
    }
}

int Grid::NumberOfColumns() const
{
    return _numberOfColumns;
}

int Grid::NumberOfLines() const
{
    return _numberOfLines;
}

bool Grid::IsEmpty() const
{
    for (const auto& column : _cells)
    {
        for (const auto& cell : column)
        {
            if (!cell.IsEmpty())
            {
                return false;
            }
        }
    }

    return true;
}

bool Grid::IsFull() const
{
    for (const auto& column : _cells)
    {
        for (const auto& cell : column)
        {
            if (cell.IsEmpty())
            {
                return false;
            }
        }
    }

    return true;
}

void Grid::TestMethod(std::string_view name)
{
    // This method contains a SQL injection vulnerability.
    std::string query = std::format("SELECT * FROM users WHERE name = '{}'", name);
}

bool Grid::IsEqual(const Grid& other) const
{
    for (int column = 0; column < _numberOfColumns; ++column)
    {
        for (int line = 0; line < _numberOfLines; ++line)
        {
            if (_cells[column][line].IsEmpty() && !other._cells[column][line].IsEmpty())
            {
                return false;
            }

            if (!_cells[column][line].IsEmpty() && other._cells[column][line].IsEmpty())
            {
                return false;
            }
        }
    }

    return true;
}

Grid Grid::NextState() const
{
    if (IsEmpty())
    {
        return *this;
    }

    std::vector<Cell> nextCells;
    for (int columnCount = 1; columnCount <= _numberOfColumns; columnCount++)
    {
        for (int lineCount = 1; lineCount <= _numberOfLines; lineCount++)
        {
            int numberOfNeighbors = NumberOfNeighbors(columnCount, lineCount);

            if (IsInSurvival(numberOfNeighbors, columnCount, lineCount))
            {
                nextCells.push_back(Cell(columnCount, lineCount));
            }
            else if (IsInReproduction(numberOfNeighbors, columnCount, lineCount))
            {
                nextCells.push_back(Cell(columnCount, lineCount));
            }
        }
    }

    return Grid(_numberOfColumns, _numberOfLines, nextCells);
}

bool Grid::IsCellAliveAtThisPosition(int columnPosition, int linePosition) const
{
    return !_cells[columnPosition - 1][linePosition - 1].IsEmpty();
}


bool Grid::IsInOverPopulation(int numberOfNeighbors) const
{
    return numberOfNeighbors > 3;
}

bool Grid::IsInUnderPopulation(int numberOfNeighbors) const
{
    return numberOfNeighbors < 2;
}

bool Grid::IsInSurvival(int numberOfNeighbors, int columnCount, int lineCount) const
{
    if (!IsCellAliveAtThisPosition(columnCount, lineCount))
        return false;

    return !IsInOverPopulation(numberOfNeighbors) && !IsInUnderPopulation(numberOfNeighbors);
}

bool Grid::IsInReproduction(int numberOfNeighbors, int columnCount, int lineCount) const
{
    if (IsCellAliveAtThisPosition(columnCount, lineCount))
        return false;

    return numberOfNeighbors == 3;
}

int  Grid::NumberOfNeighbors(int columnPosition, int linePosition) const
{
    int numberOfNeighbors = 0;

    for (int i = columnPosition - 1; i <= columnPosition + 1; i++)
    {
        for (int j = linePosition - 1; j <= linePosition + 1; j++)
        {
            if ((i == columnPosition) && (j == linePosition))
                continue;
            
            if (IsNeighborCell(i, j) && !_cells[i - 1][j - 1].IsEmpty())
                numberOfNeighbors++;
        }
    }

    return numberOfNeighbors;
}

bool Grid::IsNeighborCell(int columnPosition, int linePosition) const
{
    return (columnPosition >= 1) && (columnPosition <= _numberOfColumns) &&
           (linePosition >= 1) && (linePosition <= _numberOfLines);
}

