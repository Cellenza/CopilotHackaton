const Game = require('./Game');
const Grid = require('./Grid');
const Cell = require('./Cell');

test('givenAnGridWithAllCellsDead_TheGameIsFinishedAfterTheFirstRound', () => {
    const grid = new Grid(1, 1, []);
    const game = new Game(grid);

    game.run();

    expect(game.isFinished).toBe(true);
});

test('givenInitialState_ThenNotFinished', () => {
    const grid = new Grid(1, 1, []);
    const game = new Game(grid);

    expect(game.isFinished).toBe(false);
});

test('givenA1xA1GridWith1Cell_GameIsNotFinishedAfterOneRound', () => {
    const cell = new Cell(1, 1);
    const grid = new Grid(1, 1, [cell]);
    const game = new Game(grid);

    game.run();

    expect(game.isFinished).toBe(false);
});

test('givenA1xA1GridWithCell_GameIsFinishedAfterTwoRounds', () => {
    const cell = new Cell(1, 1);
    const grid = new Grid(1, 1, [cell]);
    const game = new Game(grid);

    game.run();
    game.run();

    expect(game.isFinished).toBe(true);
});

test('givenA2xA2GridWith2Cells_GameIsFinishedAfterTwoRounds', () => {
    const cell1 = new Cell(1, 1);
    const cell2 = new Cell(1, 1);
    const grid = new Grid(2, 2, [cell1, cell2]);
    const game = new Game(grid);

    game.run();
    game.run();

    expect(game.isFinished).toBe(true);
});

test('givenA2xA2GridWith3Cells_GameIsFinishedAfterTwoRounds', () => {
    const cell1 = new Cell(1, 1);
    const cell2 = new Cell(1, 2);
    const cell3 = new Cell(2, 1);
    const grid = new Grid(2, 2, [cell1, cell2, cell3]);
    const game = new Game(grid);

    game.run();
    game.run();

    expect(game.isFinished).toBe(true);
    expect(game.gridIsEmpty()).toBe(false);
});

test('givenABlockInA4x4Grid_GameIsFinishedAfterOneRound', () => {
    const cell1 = new Cell(2, 2);
    const cell2 = new Cell(2, 3);
    const cell3 = new Cell(3, 2);
    const cell4 = new Cell(3, 3);
    const grid = new Grid(4, 4, [cell1, cell2, cell3, cell4]);
    const game = new Game(grid);

    game.run();

    expect(game.isFinished).toBe(true);
});

test('given3CellsInA2x3Grid_GameIsNotFinishedAfterOneRound', () => {
    const cell1 = new Cell(1, 1);
    const cell2 = new Cell(2, 2);
    const cell3 = new Cell(1, 3);
    const grid = new Grid(2, 3, [cell1, cell2, cell3]);
    const game = new Game(grid);

    game.run();

    expect(game.isFinished).toBe(false);
});

test('given6CellsInA4x3Grid_GameIsNotFinishedAfterOneRound', () => {
    const cell1 = new Cell(2, 1);
    const cell2 = new Cell(3, 1);
    const cell3 = new Cell(2, 2);
    const cell4 = new Cell(3, 2);
    const cell5 = new Cell(2, 3);
    const cell6 = new Cell(3, 3);
    const grid = new Grid(4, 3, [cell1, cell2, cell3, cell4, cell5, cell6]);
    const game = new Game(grid);

    game.run();

    expect(game.isFinished).toBe(false);
});