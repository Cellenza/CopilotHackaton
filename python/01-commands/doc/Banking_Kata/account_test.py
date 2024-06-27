import unittest
from account import Account

class AccountTest(unittest.TestCase):
    def test_deposit_increases_balance(self):
        # Arrange
        deposit_amount = 500
        account = Account()

        # Act
        account.deposit(deposit_amount)

        # Assert
        self.assertEqual(deposit_amount, account.balance)

    def test_withdraw_decreases_balance_and_updates_statement(self):
        # Arrange
        account = Account()
        withdraw_amount = 500

        # Act
        account.withdraw(withdraw_amount)

        # Assert
        self.assertEqual(-withdraw_amount, account.balance)

    def test_withdraw_after_deposit_updates_balance_and_statement(self):
        # Arrange
        account = Account()
        deposit_amount = 500

        # Act
        # The rest of the code is missing

if __name__ == '__main__':
    unittest.main()