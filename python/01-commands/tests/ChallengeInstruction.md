# Challenge instructions for `/tests` command

## Step 1: Generate tests for `Year.cs`

### Instructions
![alt text](images/image-8.png)

1. Open the `Year.cs` file in the `LeapYearsKata` solution.
2. Press `alt + :` with the cursor on the class name.
3. Type `/tests` and press enter.

*Note: You can specify xunit as the testing framework.*

### Observations
![alt text](images/image-7.png)

To note:
1. Copilot should propose to write the answer in a new file.
2. Check the generated tests and see if they fit with the code you are reading.

## Step 2: Generate tests for `Number.cs`

### Instructions
![alt text](images/image-9.png)

1. Open the `Number.cs` file in the `SumOfDigits` solution.
2. Press `alt + :` with the cursor on the class name.
3. Type `/tests` and press enter.

### Observations
![alt text](images/image-10.png)

To note:
1. Copilot should propose to write the answer in a new file.
2. Check the generated tests and see if they fit with the code you are reading.

## Step 3: Generate tests for `Number.cs` using a template

### Instructions
*Open a new chat*
![alt text](images/image-11.png)

1. Open the `Number.cs` file in the `SumOfDigits` folder.
2. Press `alt + :` with the cursor on the class name.
3. Type `/tests` and specify that you want to use the file `NumberTestTemplate1` as a template.

### Observations
1. The proposed results should be different from step 2.
2. Redo the same experiment but with `NumberTestTemplate2.cs` open and check the response difference.

*Note: Copilot is good at replicating templates. Giving it examples to work on improves the output quality.*

## Step 4: Generate tests in ComplexMethod project

### Instructions

1. Generate test for the method `Execute` in `SearchInDictionary.cs`
2. Save the generated file under ``SearchInDictionaryTestsStep1.cs``
3. Replace `VerifyIpAddress` call in Execute by `VerifyIpAddressSimple`
4. Generate test for the method `Execute` in `SearchInDictionary.cs`
5. Compare ``SearchInDictionaryTestsStep1.cs`` with the previous result

### Observations

1. There is a limit of number of test that can be generated
2. You need small methods to generate efficiant test with Copilot 
3. With many nested methods, you can't generate all unit tests