package com.training.app;

import java.util.List;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class GridTest {

    @Test
    public void whenTryingToCreateA1x1Grid_AGridWithOneColumnAndOneLineIsCreated() {
        int columnNumber = 1;
        int lineNumber = 1;
        Cell cell = new Cell(1, 1);

        Grid grid = new Grid(columnNumber, lineNumber, List.of(cell));

        assertEquals(columnNumber, grid.getNumberOfColumns());
        assertEquals(lineNumber, grid.getNumberOfLines());
        assertFalse(grid.isEmpty());
    }

    @Test
    public void whenACellIsAliveAndHas2or3Neighbours_ItIsAliveNextRound() {
        int columnNumber = 2;
        int lineNumber = 2;
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(1, 2);
        Cell cell3 = new Cell(2, 1);

        Grid grid = new Grid(columnNumber, lineNumber, List.of(cell1, cell2, cell3));

        Grid gridNextState = grid.nextState();

        assertTrue(gridNextState.cellIsAliveAtThisPosition(1, 1));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(1, 2));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(2, 1));
    }

    @Test
    public void whenACellIsAliveAndHasLessThan2Neighbours_ItIsDeadNextRound() {
        int columnNumber = 2;
        int lineNumber = 2;
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(1, 2);

        Grid grid = new Grid(columnNumber, lineNumber, List.of(cell1, cell2));

        Grid gridNextState = grid.nextState();

        assertFalse(gridNextState.cellIsAliveAtThisPosition(1, 1));
        assertFalse(gridNextState.cellIsAliveAtThisPosition(1, 2));
        assertFalse(gridNextState.cellIsAliveAtThisPosition(2, 1));
        assertFalse(gridNextState.cellIsAliveAtThisPosition(2, 2));
    }

    @Test
    public void whenACellIsAliveAndHasMoreThan3Neighbours_ItDiesFromOverpopulationNextRound() {
        int columnNumber = 2;
        int lineNumber = 3;
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(2, 1);
        Cell cell3 = new Cell(1, 2);
        Cell cell4 = new Cell(2, 2);
        Cell cell5 = new Cell(2, 3);

        Grid grid = new Grid(columnNumber, lineNumber, List.of(cell1, cell2, cell3, cell4, cell5));

        Grid gridNextState = grid.nextState();

        assertTrue(gridNextState.cellIsAliveAtThisPosition(cell1.getColumnPosition(), cell1.getLinePosition()));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(cell2.getColumnPosition(), cell2.getLinePosition()));
        assertFalse(gridNextState.cellIsAliveAtThisPosition(cell3.getColumnPosition(), cell3.getLinePosition()));
        assertFalse(gridNextState.cellIsAliveAtThisPosition(cell4.getColumnPosition(), cell4.getLinePosition()));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(cell5.getColumnPosition(), cell5.getLinePosition()));
    }

    @Test
    public void whenACellIsDeadAndHas3Neighbours_ItComesAliveNextRound() {
        int columnNumber = 2;
        int lineNumber = 2;
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(2, 1);
        Cell cell3 = new Cell(1, 2);

        Grid grid = new Grid(columnNumber, lineNumber, List.of(cell1, cell2, cell3));

        Grid gridNextState = grid.nextState();

        assertTrue(gridNextState.cellIsAliveAtThisPosition(cell1.getColumnPosition(), cell1.getLinePosition()));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(cell2.getColumnPosition(), cell2.getLinePosition()));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(cell3.getColumnPosition(), cell3.getLinePosition()));
        assertTrue(gridNextState.cellIsAliveAtThisPosition(2, 2));
    }

    @Test
    public void whenACellIsAliveAndHasLessThan3Neighbours_ItDiesFromUnderpopulationNextRound() {
        int columnNumber = 2;
        int lineNumber = 2;
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(2, 1);

        Grid grid = new Grid(columnNumber, lineNumber, List.of(cell1, cell2));

        Grid gridNextState = grid.nextState();

        assertFalse(gridNextState.cellIsAliveAtThisPosition(cell1.getColumnPosition(), cell1.getLinePosition()));
        assertFalse(gridNextState.cellIsAliveAtThisPosition(cell2.getColumnPosition(), cell2.getLinePosition()));
    }
}
