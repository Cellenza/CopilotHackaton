package com.training.app;

public class Game {
    private Grid _grid;
    private boolean isFinished;

    public Game(Grid grid) {
        _grid = grid;
        isFinished = false;
    }

    public void run() {
        Grid nextGrid = _grid.nextState();

        if (_grid.isEqual(nextGrid)) {
            isFinished = true;
        }
        _grid = nextGrid;
    }

    public boolean gridIsEmpty() {
        return _grid.isEmpty();
    }

    public boolean isFinished() {
        return isFinished;
    }
}
