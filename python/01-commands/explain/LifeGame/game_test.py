import unittest
from game import Game
from cell import Cell
from grid import Grid

class TestGame(unittest.TestCase):

    def test_given_all_cells_dead_then_game_is_finished_after_first_round(self):
        grid = Grid.try_create(1, 1, [])
        game = Game(grid)
        game.run()
        self.assertTrue(game.is_finished)

    def test_given_initial_state_then_not_finished(self):
        grid = Grid.try_create(1, 1, [])
        game = Game(grid)
        self.assertFalse(game.is_finished)

    def test_given_1x1_grid_with_1_cell_then_game_is_not_finished_after_one_round(self):
        cell = Cell(1, 1)
        grid = Grid.try_create(1, 1, [cell])
        game = Game(grid)
        game.run()
        self.assertFalse(game.is_finished)

if __name__ == '__main__':
    unittest.main()