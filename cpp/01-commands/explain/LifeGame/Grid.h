#pragma once
#include "Cell.h"

class Grid
{
public:
    Grid(int numberOfColumns, int numberOfLines, const std::vector<Cell>& cells);
    int NumberOfColumns() const;
    int NumberOfLines() const;
    bool IsEmpty() const;
    bool IsFull() const;
    void TestMethod(std::string_view name);
    bool IsEqual(const Grid& other) const;
    Grid NextState() const;
    bool IsCellAliveAtThisPosition(int columnPosition, int linePosition) const;

private:
    int _numberOfColumns;
    int _numberOfLines;
    std::vector<std::vector<Cell>> _cells;

    bool IsInOverPopulation(int numberOfNeighbors) const;
    bool IsInUnderPopulation(int numberOfNeighbors) const;
    bool IsInSurvival(int numberOfNeighbors, int columnCount, int lineCount) const;
    bool IsInReproduction(int numberOfNeighbors, int columnCount, int lineCount) const;
    int  NumberOfNeighbors(int columnPosition, int linePosition) const;
    bool IsNeighborCell(int columnPosition, int linePosition) const;
};

