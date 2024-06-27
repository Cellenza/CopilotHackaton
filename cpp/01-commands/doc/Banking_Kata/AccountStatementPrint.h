#pragma once
#include "BankingTransactionDTO.h"

std::string PrintDate(const timepoint& date);
std::string PrintStatement(const std::vector<BankingTransactionDTO>& statement);
