import unittest
from datetime import datetime
from banking_transaction_dto import BankingTransactionDTO
from account_statement_print import print_statement

class AccountStatementPrintTest(unittest.TestCase):
    def test_print_statement_after_first_deposit(self):
        # Arrange
        statement = []
        expected_output = "Date Amount Balance\n" + \
                          f"{datetime.today().strftime('%m/%d/%Y')} +500 500\n"

        # Act
        statement.append(BankingTransactionDTO(datetime.today(), 500, 500))

        # Assert
        self.assertEqual(expected_output, print_statement(statement))

    def test_print_statement_after_deposit_and_withdraw(self):
        # Arrange
        statement = []
        expected_output = "Date Amount Balance\n" + \
                          f"{datetime.today().strftime('%m/%d/%Y')} +500 500\n" + \
                          f"{datetime.today().strftime('%m/%d/%Y')} -100 400\n"

        # Act
        statement.append(BankingTransactionDTO(datetime.today(), 500, 500))
        statement.append(BankingTransactionDTO(datetime.today(), -100, 400))

        # Assert
        self.assertEqual(expected_output, print_statement(statement))

if __name__ == '__main__':
    unittest.main()