class Year:
    def __init__(self, year):
        self._year = year

    def is_leap_year(self):
        if self.is_year_divisible_by(400):
            return True
        elif self.is_year_divisible_by(4) and not self.is_year_divisible_by(100):
            return True
        else:
            return False

    def is_year_divisible_by(self, to_divide_by):
        return self._year % to_divide_by == 0