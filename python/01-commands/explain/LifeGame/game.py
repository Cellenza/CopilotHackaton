from grid import Grid

class Game:
    def __init__(self, grid: Grid):
        self.grid = grid
        self.is_finished = False

    def run(self):
        next_grid = self.grid.next_state()

        if self.grid.is_equal(next_grid):
            self.is_finished = True

        self.grid = next_grid

    def grid_is_empty(self):
        return self.grid.is_empty
