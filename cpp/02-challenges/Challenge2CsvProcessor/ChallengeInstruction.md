# Challenge instructions for CsvProcessor solution

## Prerequisites
1. Open Visual Studio (Preview) 2022
2. Open the solution `Code\CsvProcessor.sln`
3. Press F5 to compile and run the solution

### Observations

Notice that the console shows multiple lines of a CSV file. 
Each line is broken down into fields. The algorithm correctly handles
double-quotes fields and escaped double-quotes in fields.

Sample output:
```
Adrienne,,D'Alencourt,987432,adale@acme.com,+33 9 12 45 56 78,Sales,EMEA,105603,1/31/2019,"5'11"""
[Adrienne] [] [D'Alencourt] [987432] [adale@acme.com] [+33 9 12 45 56 78] [Sales] [EMEA] [105603] [1/31/2019] [5'11"]
````

## Step 1: Add comment on file

1. Open `CsvProcessor.cs` file
2. Use CTRL+A to select all the content in the file
3. Type `/doc` to add comments

### Observations

A comment is created at the top of the file.


## Step 2: Use Copilot to explain some code

1. Open `CsvProcessor.cs` file
2. Select the two `import` lines towards the top of the file
3. Type `/explain`

### Observations

Copilot explains the purpose of the `import` statements -- a new keyword in C++ 20.
Copilot also provide additional hyperlinks at the end of the explanation
for further exploration.

## Step 3: Let Copilot generate code from a comment

1. Open `CsvProcessor.cs` file
2. At the top of the `main` function, place the cusor at the end of the line
   that reads `//TODO3` and press ENTER
3. Press TAB to accept the suggestion from Copilot


### Observations

When you type comments before writing a section of code, Copilot can automatically
generate the code for you. If you like the suggestion, you can accept it by pressing TAB.
If not, keep typing and Copilot will continue to suggest code.
That way, Copilot integrates seemlessly with your workflow.

## Step 4: Add comments to a block of code

1. Open `CsvProcessor.cs` file
2. In the `main` function, select the entire `for` loop.
   Hint: You can press the Down arrow in the margin to "roll in" the loop 
             in one line, then select the entire line
3. Tell Copilot to "add comments to the selected code"

### Observations

Copilot comments each meaningful block of code. This is a great way to
document existing code, or to help you understand code that you didn't write.


## Step 5: Create automated tests

1. Open the Test Explorer window by selecting the menu item `View` > `Test Explorer`
2. Run the tests by right-clicking on `LexerTest` and selecting `Run` in the context menu
3. Open `LexerTest.cpp` file  4. Uncomment the lines `TEST_METHOD(...)` one by one and press ENTER to let Copilot generate the test code for you  5. Compile with F6 and run all tests again6. Create additional test methods with meaningful names in order to guide Copilot
### Observations

Copilot generates the test code based on several assumptions. In most cases,
the generated test code passes. However, you may need to adjust the test code
for edge cases or to test specific scenarios.

## Step 6: Create more automated tests

1. Open the Test Explorer window by selecting the menu item `View` > `Test Explorer`
2. Run the tests by right-clicking on `ParserTest` and selecting `Run` in the context menu
3. Open `ParserTest.cpp` file  4. Uncomment the lines `TEST_METHOD(...)` one by one and press ENTER to let Copilot generate the test code for you  5. Compile with F6 and run all tests again6. Create additional test methods with meaningful names in order to guide Copilot
