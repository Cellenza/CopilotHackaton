# Challenge instructions for `/explain` command
## Step 1: On the main file
### Instructions
![alt text](images/image-1.png)
1. Open the `Game.java` file.
2. Press `alt + :`.
3. Type `/explain` and press enter.

### Observations
![alt text](images/image-2.png)
To notice:
1. Copilot described the entire class.
2. You can have access to the references used in the input prompt. Notice that only the open file was used.
3. Check the explanations and see if they fit with the code you are reading.

## Step 2: On multiple files
### Instructions

*Open a new chat.*

You can ask Copilot to take further files into account using `#` inside the chat.

![alt text](images/image-3.png)

### Observations

To notice:
1. This time only the specified file was taken into account.
2. Compare the result with the previous answer which used only `Game.java`.

## Step 3: On code section exclusively
### Instructions
*Open a new chat.*
1. Open the file `Grid.java`.
2. Explain the expression in `isEmpty` method
3. `#File:Grid.java:12` to only consider line 31
4. Select the method ``isFull`` and type `/explain`

### Observations

You can select all the class, a specific method or a specific line to explain