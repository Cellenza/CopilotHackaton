# Challenge instructions for `/doc` command

## Step 1: Add comments on one file

1. Open `app.js` file.
2. Use CTRL+A to select all the content in the file.
3. Type `/doc` to add comments.
4. Do the same for `transaction.js`.
5. Type `/doc` to add comments.

### Observations

Comments are created for all the functions in the file.

There is not always a comment at the top of the file.
There should not be a comment on `app.js`.

## Step 2: Use Copilot Chat to have a complete comment on file

1. Open Copilot Chat to generate a comment at the top of the file.
2. `#app.js Give me a comment to describe the file app.js`.
3. Ask for a shorter comment.

### Observations

You can generate a complete comment and reduce it.
Copilot keeps the context of the previous question.

## Step 3: Add comments to a test function

1. Open `app.test.js` file.
2. Select the function `testWithdrawAfterDeposit` and type `/doc`.
3. Rename the function `testWithdrawAfterDepositUpdated` and type `/doc`.

### Observations

Comments are generated from the function name.
Your code needs to be descriptive to generate good comments.

## Step 4: Add comments inside a function

1. Open Copilot Chat and type the command below.
2. `#file:printStatement.js Add comment for each statement in printStatement`.

### Observations

You can generate documentation inside complex functions.

## Step 5: Create a README.md

1. In Visual Studio Code, create a file README.md at the root of the project.
2. Type `Create me a template of README.md`.
3. Add precision to the comment with `Create me a template of README.md for Node.js Project with npm`.
4. Accept the template and open GitHub Copilot Chat.
5. Type `@workspace Create a small description for the Banking Kata project`.

### Observations

You can generate global documentation for a project.

## Step 6: Improve your documentation

1. Ask GitHub Copilot to improve your README.md file.
2. `What should I include in README.md file for a Node.js project?`.

### Observations

GitHub Copilot suggests more sections.