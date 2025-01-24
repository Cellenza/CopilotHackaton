# Challenge instructions for `/explain` command

[Version française disponible plus bas](#instructions-en-français)

## Step 1: On the main file
### Instructions
![alt text](image.png)
1. Open the `game.py` file : make sure it is the ONLY file open
2. Press `ctrl+i`.
3. Type `/explain` and press enter.

### Observations
![alt text](image-2.png)
1. Copilot described the entire class and used the command `@workspace`
2. You can have access to the references used in the input prompt. Notice that not only the opened file was used.
3. Check the explanations and see if they fit with the code you are reading.

## Step 2: On multiple files
### Instructions

*Open the chat on the left sidebar.*

![alt text](image-5.png)

You can ask Copilot to take specific files into account using `#` inside the chat.

![alt text](image-3.png)

### Observations
1. This time only the specified file was taken into account.
2. Compare the result with the previous answer which used only `game.py`.

## Step 3: On code section exclusively
### Instructions
*Open a new chat.*
1. Open the file `grid.py`.
2. Select the line 8 containing a lambda expression.
3. Press `ctrl+i` and enter `/explain`

![alt text](image-6.png)

### Observations

![alt text](image-7.png)

Line 8 was taken into account and explained instead of the whole file.

# Instructions en français

## Étape 1 : Sur le fichier principal
### Instructions
![alt text](image.png)
1. Ouvrez le fichier `game.py` : assurez-vous qu'il est le SEUL fichier ouvert
2. Appuyez sur `ctrl+i`.
3. Tapez `/explain` et appuyez sur Entrée.

### Observations
![alt text](image-2.png)
1. Copilot a décrit toute la classe et utilisé la commande `@workspace`
2. Vous pouvez accéder aux références utilisées dans l'invite de saisie. Remarquez que non seulement le fichier ouvert a été utilisé.
3. Vérifiez les explications et voyez si elles correspondent au code que vous lisez.

## Étape 2 : Sur plusieurs fichiers
### Instructions

*Ouvrez le chat dans la barre latérale gauche.*

![alt text](image-5.png)

Vous pouvez demander à Copilot de prendre en compte des fichiers spécifiques en utilisant `#` dans le chat.

![alt text](image-3.png)

### Observations
1. Cette fois, seul le fichier spécifié a été pris en compte.
2. Comparez le résultat avec la réponse précédente qui n'utilisait que `game.py`.

## Étape 3 : Sur une section de code exclusivement
### Instructions
*Ouvrez un nouveau chat.*
1. Ouvrez le fichier `grid.py`.
2. Sélectionnez la ligne 8 contenant une expression lambda.
3. Appuyez sur `ctrl+i` et entrez `/explain`

![alt text](image-6.png)

### Observations

![alt text](image-7.png)

La ligne 8 a été prise en compte et expliquée au lieu de tout le fichier.