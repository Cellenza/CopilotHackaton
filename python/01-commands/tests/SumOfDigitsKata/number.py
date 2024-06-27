class Number:
    def __init__(self, number):
        self._number = number

    def digital_root(self):
        result = 0

        while self._number > 0:
            result += self._number % 10
            self._number = self._number // 10

        if result > 9:
            number = Number(result)
            result = number.digital_root()

        return result