#include "pch.h"
#include "AccountStatementPrint.h"

using namespace std::chrono;

std::string PrintDate(const timepoint& date)
{
    year_month_day ymd(floor<days>(date));
    return std::format("{:04}-{:02}-{:02}", 
               static_cast<int>(ymd.year()), 
               static_cast<unsigned>(ymd.month()), 
               static_cast<unsigned>(ymd.day()));
}


std::string PrintStatement(const std::vector<BankingTransactionDTO>& statement)
{
    std::string printedStatement = "Date Amount Balance\n";
    
    for (const auto& transaction : statement)
    {
        printedStatement += std::format("{} {:+} {}\n",
            PrintDate(transaction.getDate()),
            transaction.getAmount(),
            transaction.getBalance());
    }

    return printedStatement;
}
