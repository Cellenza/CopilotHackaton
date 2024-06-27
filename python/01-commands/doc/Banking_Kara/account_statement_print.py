def print_statement(transaction_list):
    printed_statement = "Date Amount Balance\n"
    for transaction in transaction_list:
        printed_statement += f"{transaction.date.strftime('%m/%d/%Y')} " \
                             f"{'+' if transaction.amount >= 0 else ''}{transaction.amount} " \
                             f"{transaction.balance}\n"
    return printed_statement