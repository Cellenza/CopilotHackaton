# Challenge instructions for `/tests` command

[Version française disponible plus bas](#instructions-en-français)

## Step 1: Generate tests for `Year.cpp`

### Instructions
![alt text](images/image-8.png)

1. Open the `LeapYearsKata.cpp` file in the `LeapYearsKata` solution.
2. Press `alt + :` with the cursor on the class name.
3. Type `/tests` and press enter.

### Observations
![alt text](images/image-7.png)

To note:
1. Copilot will generate tests in `LeapYearsKata.cpp`.
2. Check the generated tests and see if they fit with the code you are reading.

## Step 2: Generate tests for `Number.cpp`

### Instructions
![alt text](images/image-9.png)

1. Open the `SumOfDigitsKata.cpp` file in the `SumOfDigitsKata` solution.
2. Press `alt + :` with the cursor on the class name.
3. Type `/tests` and press enter.

### Observations
![alt text](images/image-10.png)

To note:
1. Copilot will generate tests in `SumOfDigitsKata.cpp`.
2. Check the generated tests and see if they fit with the code you are reading.

## Step 3: Generate tests for `Number.cpp` using a template

### Instructions
*Open a new chat*
![alt text](images/image-11.png)

1. Open the `Number.cpp` file in the `SumOfDigits` folder.
2. Press `alt + :` with the cursor on the class name.
3. Type `/tests` and specify that you want to use the file `NumberTestTemplate1` as a template.

### Observations
1. The proposed results should be different from step 2.
2. Redo the same experiment but with `NumberTestTemplate2.cpp` open and check the response difference.

*Note: Copilot is good at replicating templates. Giving it examples to work on improves the output quality.*

## Step 4: Generate tests in ComplexMethod project

### Instructions

1. Generate test for the method `Execute` in `SearchInDictionary.cpp`
2. Save the generated file under `SearchInDictionaryTestsStep1.cpp`
3. Replace `VerifyIpAddress` call in Execute by `VerifyIpAddressSimple`
4. Generate test for the method `Execute` in `SearchInDictionary.cpp`
5. Compare `SearchInDictionaryTestsStep1.cpp` with the previous result

### Observations

1. There is a limit of number of tests that can be generated
2. You need small methods to generate efficient tests with Copilot 
3. With many nested methods, you can't generate all unit tests

# Instructions en français pour la commande `/tests`

## Étape 1 : Générer des tests pour `Year.cpp`

### Instructions
![alt text](images/image-8.png)

1. Ouvrez le fichier `LeapYearsKata.cpp` dans la solution `LeapYearsKata`.
2. Appuyez sur `alt + :` avec le curseur sur le nom de la classe.
3. Tapez `/tests` et appuyez sur Entrée.

### Observations
![alt text](images/image-7.png)

À noter :
1. Copilot générera des tests dans `LeapYearsKata.cpp`.
2. Vérifiez les tests générés et voyez s'ils correspondent au code que vous lisez.

## Étape 2 : Générer des tests pour `Number.cpp`

### Instructions
![alt text](images/image-9.png)

1. Ouvrez le fichier `SumOfDigitsKata.cpp` dans la solution `SumOfDigitsKata`.
2. Appuyez sur `alt + :` avec le curseur sur le nom de la classe.
3. Tapez `/tests` et appuyez sur Entrée.

### Observations
![alt text](images/image-10.png)

À noter :
1. Copilot générera des tests dans `SumOfDigitsKata.cpp`.
2. Vérifiez les tests générés et voyez s'ils correspondent au code que vous lisez.

## Étape 3 : Générer des tests pour `Number.cpp` en utilisant un modèle

### Instructions
*Ouvrez une nouvelle discussion*
![alt text](images/image-11.png)

1. Ouvrez le fichier `Number.cpp` dans le dossier `SumOfDigits`.
2. Appuyez sur `alt + :` avec le curseur sur le nom de la classe.
3. Tapez `/tests` et spécifiez que vous souhaitez utiliser le fichier `NumberTestTemplate1` comme modèle.

### Observations
1. Les résultats proposés devraient être différents de l'étape 2.
2. Refaites la même expérience mais avec `NumberTestTemplate2.cpp` ouvert et vérifiez la différence de réponse.

*Remarque : Copilot est bon pour reproduire des modèles. Lui donner des exemples sur lesquels travailler améliore la qualité des résultats.*

## Étape 4 : Générer des tests dans le projet ComplexMethod

### Instructions

1. Générez un test pour la méthode `Execute` dans `SearchInDictionary.cpp`
2. Enregistrez le fichier généré sous `SearchInDictionaryTestsStep1.cpp`
3. Remplacez l'appel `VerifyIpAddress` dans Execute par `VerifyIpAddressSimple`
4. Générez un test pour la méthode `Execute` dans `SearchInDictionary.cpp`
5. Comparez `SearchInDictionaryTestsStep1.cpp` avec le résultat précédent

### Observations

1. Il y a une limite au nombre de tests qui peuvent être générés
2. Vous avez besoin de petites méthodes pour générer des tests efficaces avec Copilot
3. Avec de nombreuses méthodes imbriquées, vous ne pouvez pas générer tous les tests unitaires