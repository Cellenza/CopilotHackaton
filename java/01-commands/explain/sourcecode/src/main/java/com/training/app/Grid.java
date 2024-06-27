package com.training.app;

import java.util.List;
import java.util.Objects;
import java.util.ArrayList;
import java.util.Arrays;

public class Grid {
    private final int numberOfColumns;
    private final int numberOfLines;
    private final Cell[][] cells;

    public Grid(int numberOfColumns, int numberOfLines, List<Cell> cellsList) {
        this.numberOfColumns = numberOfColumns;
        this.numberOfLines = numberOfLines;
        this.cells = new Cell[numberOfColumns][numberOfLines];
        for (Cell cell : cellsList) {
            cells[cell.getColumnPosition() - 1][cell.getLinePosition() - 1] = cell;
        }
    }

    public int getNumberOfColumns() {
        return numberOfColumns;
    }

    public int getNumberOfLines() {
        return numberOfLines;
    }

    public boolean isEmpty() {
        return cells == null || cells.length == 0;
    }

    public boolean isFull() {
        long count = Arrays.stream(cells)
            .flatMap(Arrays::stream)
            .filter(Objects::nonNull)
            .count();
        return count == numberOfColumns * numberOfLines;
    }

    public boolean isEqual(Grid grid) {
        for (int i = 0; i < numberOfColumns; i++) {
            for (int j = 0; j < numberOfLines; j++) {
                if ((cells[i][j] == null && grid.cells[i][j] != null)
                        || (cells[i][j] != null && grid.cells[i][j] == null)) {
                    return false;
                }
            }
        }
        return true;
    }

    public Grid nextState() {
        if (isEmpty()) {
            return this;
        }

        List<Cell> nextCells = new ArrayList<>();

        for (int columnCount = 1; columnCount <= numberOfColumns; columnCount++) {
            for (int lineCount = 1; lineCount <= numberOfLines; lineCount++) {
                int numberOfNeighbours = getNumberOfNeighbours(columnCount, lineCount);

                if (isInSurvival(numberOfNeighbours, columnCount, lineCount)) {
                    nextCells.add(new Cell(columnCount, lineCount));
                } else if (isInReproduction(numberOfNeighbours, columnCount, lineCount)) {
                    nextCells.add(new Cell(columnCount, lineCount));
                }
            }
        }

        return new Grid(numberOfColumns, numberOfLines, nextCells);
    }

    private boolean isInOverPopulation(int numberOfNeighbours) {
        return numberOfNeighbours > 3;
    }

    private boolean isInUnderPopulation(int numberOfNeighbours) {
        return numberOfNeighbours < 2;
    }

    private boolean isInSurvival(int numberOfNeighbours, int columnCount, int lineCount) {
        if (!cellIsAliveAtThisPosition(columnCount, lineCount)) {
            return false;
        }

        return !(isInOverPopulation(numberOfNeighbours) || isInUnderPopulation(numberOfNeighbours));
    }

    private boolean isInReproduction(int numberOfNeighbours, int columnCount, int lineCount) {
        if (cellIsAliveAtThisPosition(columnCount, lineCount)) {
            return false;
        }

        return numberOfNeighbours == 3;
    }

    public boolean cellIsAliveAtThisPosition(int columnPosition, int linePosition) {
        return cells[columnPosition - 1][linePosition - 1] != null;
    }

    private int getNumberOfNeighbours(int columnPosition, int linePosition) {
        int neighboursCount = 0;
        for (int i = columnPosition - 1; i <= columnPosition + 1; i++) {
            for (int j = linePosition - 1; j <= linePosition + 1; j++) {
                if (i == columnPosition && j == linePosition) {
                    continue;
                }

                if (isNeighbourCell(i, j) && cells[i - 1][j - 1] != null) {
                    neighboursCount++;
                }
            }
        }
        return neighboursCount;
    }

    private boolean isNeighbourCell(int columnPosition, int linePosition) {
        return columnPosition >= 1 && columnPosition <= numberOfColumns
                && linePosition >= 1 && linePosition <= numberOfLines;
    }
}
