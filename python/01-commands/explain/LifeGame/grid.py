from typing import List
from .cell import Cell

class Grid:
    def __init__(self, number_of_columns: int, number_of_lines: int, cells_list: List[Cell]):
        self.number_of_columns = number_of_columns
        self.number_of_lines = number_of_lines
        self.cells = [[None for _ in range(number_of_lines)] for _ in range(number_of_columns)]
        for cell in cells_list:
            self.cells[cell.column_position - 1][cell.line_position - 1] = cell

    @staticmethod
    def try_create(column_number: int, line_number: int, cells: List[Cell]):
        if column_number <= 0 or line_number <= 0:
            raise ValueError("Invalid grid dimensions")
        return Grid(column_number, line_number, cells)

    def is_equal(self, grid):
        for i in range(self.number_of_columns):
            for j in range(self.number_of_lines):
                if (self.cells[i][j] is None and grid.cells[i][j] is not None) or \
                   (self.cells[i][j] is not None and grid.cells[i][j] is None):
                    return False
        return True

    def next_state(self):
        if self.is_empty:
            return self

        next_cells = []
        for column_count in range(1, self.number_of_columns + 1):
            for line_count in range(1, self.number_of_lines + 1):
                number_of_neighbours = self.get_number_of_neighbours(column_count, line_count)

                if self.is_in_survival(number_of_neighbours, column_count, line_count):
                    next_cells.append(Cell(column_count, line_count))
                elif self.is_in_reproduction(number_of_neighbours, column_count, line_count):
                    next_cells.append(Cell(column_count, line_count))

        return Grid(self.number_of_columns, self.number_of_lines, next_cells)

    def is_in_over_population(self, number_of_neighbours):
        return number_of_neighbours > 3

    def is_in_under_population(self, number_of_neighbours):
        return number_of_neighbours < 2

    def is_in_survival(self, number_of_neighbours, column_count, line_count):
        if not self.cell_is_alive_at_this_position(column_count, line_count):
            return False

        return not (self.is_in_over_population(number_of_neighbours) or self.is_in_under_population(number_of_neighbours))

    def is_in_reproduction(self, number_of_neighbours, column_count, line_count):
        if self.cell_is_alive_at_this_position(column_count, line_count):
            return False

        return number_of_neighbours == 3

    def cell_is_alive_at_this_position(self, column_position, line_position):
        return self.cells[column_position - 1][line_position - 1] is not None

    def get_number_of_neighbours(self, column_position, line_position):
        neighbours_count = 0
        for i in range(max(0, column_position - 2), min(self.number_of_columns, column_position)):
            for j in range(max(0, line_position - 2), min(self.number_of_lines, line_position)):
                if i == column_position - 1 and j == line_position - 1:
                    continue

                if self.cells[i][j] is not None:
                    neighbours_count += 1

        return neighbours_count

    @property
    def is_empty(self):
        return all(cell is None for row in self.cells for cell in row)

