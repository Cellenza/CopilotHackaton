package com.training.app;

import java.util.ArrayList;
import java.util.Arrays;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class GameTest {

    @Test 
    public void givenAnGridWithAllCellsDead_TheGameIsFinishedAfterThFirstRound() {
        Grid grid = new Grid(1, 1, new ArrayList<>());
        Game game = new Game(grid);

        game.run();

        assertTrue(game.isFinished());
    }

    @Test
    public void givenInitialState_ThenNotFinished() {
        Grid grid = new Grid(1, 1, new ArrayList<>());
        Game game = new Game(grid);

        assertFalse(game.isFinished());
    }

    @Test
    public void givenA1xA1GridWith1Cell_GameIsNotFinishedAfterOneRound() {
        Cell cell = new Cell(1, 1);
        Grid grid = new Grid(1, 1, Arrays.asList(cell));

        Game game = new Game(grid);

        game.run();

        assertFalse(game.isFinished());
    }

    @Test
    public void givenA1xA1GridWithCell_GameIsFinishedAfterTwoRounds() {
        Cell cell = new Cell(1, 1);
        Grid grid = new Grid(1, 1, Arrays.asList(cell));

        Game game = new Game(grid);

        game.run();
        game.run();

        assertTrue(game.isFinished());
    }

    @Test
    public void givenA2xA2GridWith2Cells_GameIsFinishedAfterTwoRounds() {
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(1, 1);
        Grid grid = new Grid(2, 2, Arrays.asList(cell1, cell2));

        Game game = new Game(grid);
        game.run();
        game.run();

        assertTrue(game.isFinished());
    }

    @Test
    public void givenA2xA2GridWith3Cells_GameIsFinishedAfterTwoRounds() {
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(1, 2);
        Cell cell3 = new Cell(2, 1);
        Grid grid = new Grid(2, 2, Arrays.asList(cell1, cell2, cell3));

        Game game = new Game(grid);
        game.run();
        game.run();

        assertTrue(game.isFinished());
        assertFalse(game.gridIsEmpty());
    }

    @Test
    public void givenABlockInA4x4Grid_GameIsFinishedAfterOneRound() {
        Cell cell1 = new Cell(2, 2);
        Cell cell2 = new Cell(2, 3);
        Cell cell3 = new Cell(3, 2);
        Cell cell4 = new Cell(3, 3);
        Grid grid = new Grid(4, 4, Arrays.asList(cell1, cell2, cell3, cell4));
        Game game = new Game(grid);

        game.run();

        assertTrue(game.isFinished());
    }

    @Test
    public void given3CellsInA2x3Grid_GameIsNotFinishedAfterOneRound() {
        Cell cell1 = new Cell(1, 1);
        Cell cell2 = new Cell(2, 2);
        Cell cell3 = new Cell(1, 3);
        Grid grid = new Grid(2, 3, Arrays.asList(cell1, cell2, cell3));
        Game game = new Game(grid);

        game.run();

        assertFalse(game.isFinished());
    }

    @Test
    public void given6CellsInA4x3Grid_GameIsNotFinishedAfterOneRound() {
        Cell cell1 = new Cell(2, 1);
        Cell cell2 = new Cell(3, 1);
        Cell cell3 = new Cell(2, 2);
        Cell cell4 = new Cell(3, 2);
        Cell cell5 = new Cell(2, 3);
        Cell cell6 = new Cell(3, 3);
        Grid grid = new Grid(4, 3, Arrays.asList(cell1, cell2, cell3, cell4, cell5, cell6));
        Game game = new Game(grid);

        game.run();

        assertFalse(game.isFinished());
    }
}