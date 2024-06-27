import unittest
from number import Number

class TestNumber(unittest.TestCase):
    def test_digital_root(self):
        number = Number(0)
        self.assertEqual(number.digital_root(), 0)

        number = Number(10)
        self.assertEqual(number.digital_root(), 1)

if __name__ == '__main__':
    unittest.main()