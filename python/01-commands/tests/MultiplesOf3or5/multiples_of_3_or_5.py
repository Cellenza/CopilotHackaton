class MultiplesOf3or5:
    def __init__(self, number):
        self._number = number

    def sum(self):
        if self._number < 0:
            return 0

        sum = 0

        while self._number > 0:
            self._number -= 1
            if self._number % 3 == 0 or self._number % 5 == 0:
                sum += self._number

        return sum