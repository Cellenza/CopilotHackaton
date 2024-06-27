from datetime import date
from banking_transaction_dto import BankingTransactionDTO

class Account:
    def __init__(self):
        self.balance = 0
        self.statement = []

    def deposit(self, deposit_amount):
        self.balance += deposit_amount
        self.statement.append(BankingTransactionDTO(date.today(), deposit_amount, self.balance))

    def withdraw(self, withdraw_amount):
        self.balance -= withdraw_amount
        self.statement.append(BankingTransactionDTO(date.today(), -withdraw_amount, self.balance))