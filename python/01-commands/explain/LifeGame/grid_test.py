import unittest
from grid import Grid
from cell import Cell

class TestGrid(unittest.TestCase):

    def test_try_create_without_column(self):
        for column_number in [0, -1]:
            with self.assertRaises(ValueError):
                Grid.try_create(column_number, 1, [Cell(1, 1)])

    def test_try_create_without_line(self):
        for line_number in [0, -1]:
            with self.assertRaises(ValueError):
                Grid.try_create(1, line_number, [Cell(1, 1)])

if __name__ == '__main__':
    unittest.main()