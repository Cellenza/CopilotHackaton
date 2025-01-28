class Cell {
    constructor(columnPosition, linePosition) {
        this.columnPosition = columnPosition;
        this.linePosition = linePosition;
    }

    getColumnPosition() {
        return this.columnPosition;
    }

    getLinePosition() {
        return this.linePosition;
    }
}

module.exports = Cell;