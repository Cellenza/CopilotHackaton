#include "pch.h"
#include "CppUnitTest.h"
#include "Account.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace BankingKata
{
	TEST_CLASS(AccountTest)
	{
	public:
		
		TEST_METHOD(WhenDepositMade_AccountIncreasesByAmountAndStatementUpdated)
		{
            constexpr long amount = 500;
            Account account;
            account.Deposit(amount);
            const auto& statement = account.getStatement();
            Assert::AreEqual(size_t(1), statement.size());
            Assert::AreEqual(amount, statement[0].getAmount());
            Assert::AreEqual(amount, statement[0].getBalance());
            Assert::AreEqual(amount, account.getBalance());
        }

		TEST_METHOD(WhenWithdrawalMade_AccountDecreasesByAmountAndStatementUpdated)
		{
            constexpr long amount = 500;
            Account account;
            account.Withdrawal(amount);
            const auto& statement = account.getStatement();
            Assert::AreEqual(size_t(1), statement.size());
            Assert::AreEqual(-amount, statement[0].getAmount());
            Assert::AreEqual(-amount, statement[0].getBalance());
            Assert::AreEqual(-amount, account.getBalance());
        }

        TEST_METHOD(WhenMultipleDepositsMade_AccountIncreasesBySumOfAmountsAndStatementUpdated)
        {
            constexpr long amount1 = 500;
            constexpr long amount2 = 1000;
            Account account;
            account.Deposit(amount1);
            account.Deposit(amount2);
            const auto& statement = account.getStatement();
            Assert::AreEqual(size_t(2), statement.size());
            Assert::AreEqual(amount1, statement[0].getAmount());
            Assert::AreEqual(amount1, statement[0].getBalance());
            Assert::AreEqual(amount2, statement[1].getAmount());
            Assert::AreEqual(amount1 + amount2, statement[1].getBalance());
            Assert::AreEqual(amount1 + amount2, account.getBalance());
        }

        TEST_METHOD(WhenMultipleWithdrawalsMade_AccountDecreasesBySumOfAmountsAndStatementUpdated)
        {
            constexpr long amount1 = 500;
            constexpr long amount2 = 1000;
            Account account;
            account.Withdrawal(amount1);
            account.Withdrawal(amount2);
            const auto& statement = account.getStatement();
            Assert::AreEqual(size_t(2), statement.size());
            Assert::AreEqual(-amount1, statement[0].getAmount());
            Assert::AreEqual(-amount1, statement[0].getBalance());
            Assert::AreEqual(-amount2, statement[1].getAmount());
            Assert::AreEqual(-amount1 - amount2, statement[1].getBalance());
            Assert::AreEqual(-amount1 - amount2, account.getBalance());
        }

        TEST_METHOD(WhenDepositAndWithdrawalMade_AccountIncreasesAndDecreasesByAmountsAndStatementUpdated)
        {
            constexpr long depositAmount = 500;
            constexpr long withdrawalAmount = 1000;
            Account account;
            account.Deposit(depositAmount);
            account.Withdrawal(withdrawalAmount);
            const auto& statement = account.getStatement();
            Assert::AreEqual(size_t(2), statement.size());
            Assert::AreEqual(depositAmount, statement[0].getAmount());
            Assert::AreEqual(depositAmount, statement[0].getBalance());
            Assert::AreEqual(-withdrawalAmount, statement[1].getAmount());
            Assert::AreEqual(depositAmount - withdrawalAmount, statement[1].getBalance());
            Assert::AreEqual(depositAmount - withdrawalAmount, account.getBalance());
        }
	};
}
