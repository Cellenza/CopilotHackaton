package com.training.app;

public class Cell {
    private int columnPosition;
    private int linePosition;

    public Cell(int columnPosition, int linePosition) {
        this.columnPosition = columnPosition;
        this.linePosition = linePosition;
    }

    public int getColumnPosition() {
        return columnPosition;
    }

    public int getLinePosition() {
        return linePosition;
    }
}