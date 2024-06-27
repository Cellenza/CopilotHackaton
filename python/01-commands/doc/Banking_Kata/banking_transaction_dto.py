from datetime import datetime

class BankingTransactionDTO:
    def __init__(self, date, amount, balance):
        self._date = date
        self._amount = amount
        self._balance = balance

    @property
    def date(self):
        return self._date

    @property
    def amount(self):
        return self._amount

    @property
    def balance(self):
        return self._balance