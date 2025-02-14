[Version française disponible plus bas](#version-française)

# Challenge instructions for `/doc` command

## Step 1: Add comments to the class

1. Open the `Account.py` file.
2. Use CTRL+A to select all the content in the file.
3. Press `ctrl+i` and type `/doc` to add comments.

![alt text](image-2.png)

4. Select only the class name in `BankingTransactionDTO.py`.
5. Type `/doc` to add comments.

### Observations

Comments are created for all the methods of the class.

There is not always a comment at the top of the class name.
There should not be a comment on Account.py.

## Step 2: Use Copilot Chat to generate a complete comment for the class name

1. Open Copilot Chat to generate a comment at the top of the class.
2. `#Account.py write a comment to describe the class Account`.
3. Ask for a shorter or longer comment.

![alt text](image-3.png)

### Observations

You can generate a complete comment and then modify it.
Copilot uses the context of the previous question.

## Step 3: Add comments to a test method

1. Open the `AccountTest.py` file.
2. Select the method `WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeEqualToDepositMinusWithDrawAndStatementUpdated` and type `/doc`.
3. Rename the method to `WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeUpdated` and type `/doc`.

### Observations

Comments are generated using the method name.

Your code needs to be descriptive to generate good comments.

## Step 4: Add comments inside a method

Open ``AccountStatementPrint.py`` and type the following command: `/doc Add a comment for each statement in PrintStatement`

![alt text](image-4.png)

### Observations

You can generate documentation inside complex methods.

## Step 5: Create a README.md

1. In Visual Studio Code, create a file named README.md at the root of the project.
2. Type in Copilot Chat `Create a template for README.md`.
3. Add details to the comment with `Create a template for README.md for a python project`.
4. Accept the template and open Github Copilot Chat.
5. Type `@workspace Create a brief description for the Banking Kata project`.

### Observations

You can generate overall documentation for a project.

## Step 6: Improve your documentation

1. Ask Github Copilot to improve your README.md file.
2. `What should I include in the README.md file for a python project?`

### Observations

Github Copilot suggests additional sections.

# Version française

# Instructions de défi pour la commande `/doc`

## Étape 1 : Ajouter des commentaires à la classe

1. Ouvrez le fichier `Account.py`.
2. Utilisez CTRL+A pour sélectionner tout le contenu du fichier.
3. Appuyez sur `ctrl+i` et tapez `/doc` pour ajouter des commentaires.

![alt text](image-2.png)

4. Sélectionnez uniquement le nom de la classe dans `BankingTransactionDTO.py`.
5. Tapez `/doc` pour ajouter des commentaires.

### Observations

Les commentaires sont créés pour toutes les méthodes de la classe.

Il n'y a pas toujours de commentaire en haut du nom de la classe.
Il ne devrait pas y avoir de commentaire sur Account.py.

## Étape 2 : Utiliser Copilot Chat pour générer un commentaire complet pour le nom de la classe

1. Ouvrez Copilot Chat pour générer un commentaire en haut de la classe.
2. `#Account.py écrivez un commentaire pour décrire la classe Account`.
3. Demandez un commentaire plus court ou plus long.

![alt text](image-3.png)

### Observations

Vous pouvez générer un commentaire complet puis le modifier.
Copilot utilise le contexte de la question précédente.

## Étape 3 : Ajouter des commentaires à une méthode de test

1. Ouvrez le fichier `AccountTest.py`.
2. Sélectionnez la méthode `WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeEqualToDepositMinusWithDrawAndStatementUpdated` et tapez `/doc`.
3. Renommez la méthode en `WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeUpdated` et tapez `/doc`.

### Observations

Les commentaires sont générés à partir du nom de la méthode.

Votre code doit être descriptif pour générer de bons commentaires.

## Étape 4 : Ajouter des commentaires à l'intérieur d'une méthode

Ouvrez ``AccountStatementPrint.py`` et tapez la commande suivante : `/doc Ajoutez un commentaire pour chaque instruction dans PrintStatement`

![alt text](image-4.png)

### Observations

Vous pouvez générer de la documentation à l'intérieur de méthodes complexes.

## Étape 5 : Créer un README.md

1. Dans Visual Studio Code, créez un fichier nommé README.md à la racine du projet.
2. Tapez dans Copilot Chat `Créez un modèle pour README.md`.
3. Ajoutez des détails au commentaire avec `Créez un modèle pour README.md pour un projet python`.
4. Acceptez le modèle et ouvrez Github Copilot Chat.
5. Tapez `@workspace Créez une brève description pour le projet Banking Kata`.

### Observations

Vous pouvez générer une documentation globale pour un projet.

## Étape 6 : Améliorer votre documentation

1. Demandez à Github Copilot d'améliorer votre fichier README.md.
2. `Que devrais-je inclure dans le fichier README.md pour un projet python ?`

### Observations

Github Copilot suggère des sections supplémentaires.