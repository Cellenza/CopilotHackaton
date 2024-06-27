#include "pch.h"
#include "CppUnitTest.h"
#include "BankingTransactionDTO.h"
#include "AccountStatementPrint.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace BankingKata
{
	TEST_CLASS(AccountStatementPrintTest)
	{
	public:
		
		TEST_METHOD(WhenFirstDepositMade_DateAmountBalanceArePrinted)
		{
			std::vector<BankingTransactionDTO> statement;
            statement.push_back(BankingTransactionDTO(system_clock::now(), +500, 500));
			auto printedStatement = PrintStatement(statement);
			auto expectedStatement = std::format(
				"Date Amount Balance\n"
				"{} +500 500\n", 
				PrintDate(system_clock::now()));
			Assert::AreEqual(expectedStatement, printedStatement);
         }

		TEST_METHOD(WhenDepositAndWithdrawalMade_DateAmountBalanceArePrinted)
		{
            std::vector<BankingTransactionDTO> statement;
            statement.push_back(BankingTransactionDTO(system_clock::now(), +500, 500));
            statement.push_back(BankingTransactionDTO(system_clock::now(), -100, 400));
            auto printedStatement = PrintStatement(statement);
			auto expectedStatement = std::format(
				"Date Amount Balance\n"
				"{0} +500 500\n"
				"{0} -100 400\n",
				PrintDate(system_clock::now()));
			Assert::AreEqual(expectedStatement, printedStatement);
         }

	};
}
