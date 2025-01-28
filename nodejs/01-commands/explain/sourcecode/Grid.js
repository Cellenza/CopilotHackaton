const Cell = require('./Cell');

class Grid {
    constructor(numberOfColumns, numberOfLines, cellsList) {
        this.numberOfColumns = numberOfColumns;
        this.numberOfLines = numberOfLines;
        this.cells = Array.from({ length: numberOfColumns }, () => Array(numberOfLines).fill(null));
        cellsList.forEach(cell => {
            this.cells[cell.getColumnPosition() - 1][cell.getLinePosition() - 1] = cell;
        });
    }

    getNumberOfColumns() {
        return this.numberOfColumns;
    }

    getNumberOfLines() {
        return this.numberOfLines;
    }

    isEmpty() {
        return this.cells.flat().every(cell => cell === null);
    }

    isFull() {
        const count = this.cells.flat().filter(cell => cell !== null).length;
        return count === this.numberOfColumns * this.numberOfLines;
    }

    isEqual(grid) {
        for (let i = 0; i < this.numberOfColumns; i++) {
            for (let j = 0; j < this.numberOfLines; j++) {
                if ((this.cells[i][j] === null && grid.cells[i][j] !== null)
                    || (this.cells[i][j] !== null && grid.cells[i][j] === null)) {
                    return false;
                }
            }
        }
        return true;
    }

    nextState() {
        if (this.isEmpty()) {
            return this;
        }

        const nextCells = [];

        for (let columnCount = 1; columnCount <= this.numberOfColumns; columnCount++) {
            for (let lineCount = 1; lineCount <= this.numberOfLines; lineCount++) {
                const numberOfNeighbours = this.getNumberOfNeighbours(columnCount, lineCount);

                if (this.isInSurvival(numberOfNeighbours, columnCount, lineCount)) {
                    nextCells.push(new Cell(columnCount, lineCount));
                } else if (this.isInReproduction(numberOfNeighbours, columnCount, lineCount)) {
                    nextCells.push(new Cell(columnCount, lineCount));
                }
            }
        }

        return new Grid(this.numberOfColumns, this.numberOfLines, nextCells);
    }

    isInOverPopulation(numberOfNeighbours) {
        return numberOfNeighbours > 3;
    }

    isInUnderPopulation(numberOfNeighbours) {
        return numberOfNeighbours < 2;
    }

    isInSurvival(numberOfNeighbours, columnCount, lineCount) {
        if (!this.cellIsAliveAtThisPosition(columnCount, lineCount)) {
            return false;
        }

        return !(this.isInOverPopulation(numberOfNeighbours) || this.isInUnderPopulation(numberOfNeighbours));
    }

    isInReproduction(numberOfNeighbours, columnCount, lineCount) {
        if (this.cellIsAliveAtThisPosition(columnCount, lineCount)) {
            return false;
        }

        return numberOfNeighbours === 3;
    }

    cellIsAliveAtThisPosition(columnPosition, linePosition) {
        return this.cells[columnPosition - 1][linePosition - 1] !== null;
    }

    getNumberOfNeighbours(columnPosition, linePosition) {
        let neighboursCount = 0;
        for (let i = columnPosition - 1; i <= columnPosition + 1; i++) {
            for (let j = linePosition - 1; j <= linePosition + 1; j++) {
                if (i === columnPosition && j === linePosition) {
                    continue;
                }

                if (this.isNeighbourCell(i, j) && this.cells[i - 1][j - 1] !== null) {
                    neighboursCount++;
                }
            }
        }
        return neighboursCount;
    }

    isNeighbourCell(columnPosition, linePosition) {
        return columnPosition >= 1 && columnPosition <= this.numberOfColumns
            && linePosition >= 1 && linePosition <= this.numberOfLines;
    }
}

module.exports = Grid;