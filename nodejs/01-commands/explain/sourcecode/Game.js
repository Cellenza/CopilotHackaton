const Grid = require('./Grid');

class Game {
    constructor(grid) {
        this._grid = grid;
        this.isFinished = false;
    }

    run() {
        const nextGrid = this._grid.nextState();

        if (this._grid.isEqual(nextGrid)) {
            this.isFinished = true;
        }
        this._grid = nextGrid;
    }

    gridIsEmpty() {
        return this._grid.isEmpty();
    }
}

module.exports = Game;