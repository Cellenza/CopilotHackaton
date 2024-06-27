# Challenge instructions for `/doc` command

## Step 1: Add commont on one class

1. Open `Account.java` file.
2. Use CTRL+A to select all the content in the file
3. Type `/doc` to add comments
4. Do the same for `BankingTransactionDTO.java`
5. Type `/doc` to add comments

### Observations

Comments are created for all the methods of the class

There is not always a comment on the top of the class name
There should not have a comment on Account.cs

## Step 2: Use Copilot Chat to have a complete comment on class name

1. Open Copilot Chat to generate a comment on top of the class
2. `#Account.java Give me a comment to descript the class Account`
3. Ask for a smaller comment

### Observations

You can generate a complete comment and reduce it.
Copilot keep the context of the previous question.

## Step 3: Add comments to a test method

1. Open `AccountTest.java` file.
2. Select the method WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeEqualToDepositMinusWithDrawAndStatementUpdated and type `/doc`
3. Rename the mehtod WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeUpdated and type `/doc`

### Observations

Comments are generated from the method name
Your code needs to be descriptive to generate good comments

## Step 4: Add comments inside a method

1. Open Copilot Chat and type the command below
2. `#file:AccountStatementPrint.java Add comment for each statement in PrintStatement`

### Observations

You can generate documentation inside complexe methods

## Step 5: Create a README.md

1. In Visual Studio Code, create a file README.md at the root of the project
2. Type `Create me a template of README.md`
3. Add precision to the comment with `Create me a template of README.md for Java Project with Maven`
4. Accept the template and open Github Copilot Chat
5. Type `@workspace Create a small description for the Banking Kata project`

### Observations

You can generate global documentation for a project

## Step 6: Improve your documentation

1. Ask Github Copilot to improve your RAEDME.me file
2. `What should I include in README.md file to a Gradle Java project ?`

### Observations

Github Copilot suggests more sections