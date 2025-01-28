const Cell = require('./Cell');
const Grid = require('./Grid');

test('Grid initializes with correct number of columns and lines', () => {
    const cellsList = [new Cell(1, 1), new Cell(2, 2)];
    const grid = new Grid(3, 3, cellsList);

    expect(grid.getNumberOfColumns()).toBe(3);
    expect(grid.getNumberOfLines()).toBe(3);
});

test('Grid isEmpty returns true for empty grid', () => {
    const grid = new Grid(3, 3, []);
    expect(grid.isEmpty()).toBe(true);
});

test('Grid isEmpty returns false for non-empty grid', () => {
    const cellsList = [new Cell(1, 1)];
    const grid = new Grid(3, 3, cellsList);
    expect(grid.isEmpty()).toBe(false);
});

test('Grid isFull returns true for full grid', () => {
    const cellsList = [
        new Cell(1, 1), new Cell(1, 2), new Cell(1, 3),
        new Cell(2, 1), new Cell(2, 2), new Cell(2, 3),
        new Cell(3, 1), new Cell(3, 2), new Cell(3, 3)
    ];
    const grid = new Grid(3, 3, cellsList);
    expect(grid.isFull()).toBe(true);
});

test('Grid isFull returns false for non-full grid', () => {
    const cellsList = [new Cell(1, 1), new Cell(2, 2)];
    const grid = new Grid(3, 3, cellsList);
    expect(grid.isFull()).toBe(false);
});

test('Grid isEqual returns true for identical grids', () => {
    const cellsList = [new Cell(1, 1), new Cell(2, 2)];
    const grid1 = new Grid(3, 3, cellsList);
    const grid2 = new Grid(3, 3, cellsList);
    expect(grid1.isEqual(grid2)).toBe(true);
});

test('Grid isEqual returns false for different grids', () => {
    const grid1 = new Grid(3, 3, [new Cell(1, 1)]);
    const grid2 = new Grid(3, 3, [new Cell(2, 2)]);
    expect(grid1.isEqual(grid2)).toBe(false);
});