# Instructions du défi pour la commande `/doc`

## Étape 1 : Ajouter des commentaires sur un fichier

1. Ouvrez le fichier `app.js`.
2. Utilisez CTRL+A pour sélectionner tout le contenu du fichier.
3. Tapez `/doc` pour ajouter des commentaires.
4. Faites de même pour `transaction.js`.
5. Tapez `/doc` pour ajouter des commentaires.

### Observations

Des commentaires sont créés pour toutes les fonctions du fichier.

Il n'y a pas toujours un commentaire en haut du fichier.
Il ne devrait pas y avoir de commentaire sur `app.js`.

## Étape 2 : Utiliser Copilot Chat pour avoir un commentaire complet sur le fichier

1. Ouvrez Copilot Chat pour générer un commentaire en haut du fichier.
2. `#app.js Donne-moi un commentaire pour décrire le fichier app.js`.
3. Demandez un commentaire plus court.

### Observations

Vous pouvez générer un commentaire complet et le réduire.
Copilot garde le contexte de la question précédente.

## Étape 3 : Ajouter des commentaires à une fonction de test

1. Ouvrez le fichier `app.test.js`.
2. Sélectionnez la fonction `testWithdrawAfterDeposit` et tapez `/doc`.
3. Renommez la fonction `testWithdrawAfterDepositUpdated` et tapez `/doc`.

### Observations

Les commentaires sont générés à partir du nom de la fonction.
Votre code doit être descriptif pour générer de bons commentaires.

## Étape 4 : Ajouter des commentaires à l'intérieur d'une fonction

1. Ouvrez Copilot Chat et tapez la commande ci-dessous.
2. `#file:printStatement.js Ajouter un commentaire pour chaque instruction dans printStatement`.

### Observations

Vous pouvez générer de la documentation à l'intérieur de fonctions complexes.

## Étape 5 : Créer un README.md

1. Dans Visual Studio Code, créez un fichier README.md à la racine du projet.
2. Tapez `Créez-moi un modèle de README.md`.
3. Ajoutez des précisions au commentaire avec `Créez-moi un modèle de README.md pour un projet Node.js avec npm`.
4. Acceptez le modèle et ouvrez GitHub Copilot Chat.
5. Tapez `@workspace Créez une petite description pour le projet Banking Kata`.

### Observations

Vous pouvez générer une documentation globale pour un projet.

## Étape 6 : Améliorer votre documentation

1. Demandez à GitHub Copilot d'améliorer votre fichier README.md.
2. `Que devrais-je inclure dans le fichier README.md pour un projet Node.js ?`.

### Observations

GitHub Copilot suggère plus de sections.
