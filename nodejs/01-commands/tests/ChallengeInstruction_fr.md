# Instructions de défi pour la commande `/tests`

## Étape 1 : Générer des tests pour `Year.js`

### Instructions

1. Ouvrez le fichier `Year.js` dans le dossier `LeapYearsKata`.
2. Appuyez sur `alt + I` avec le curseur sur le nom de la classe.
3. Tapez `/tests` et appuyez sur entrer.

*Remarque : Vous pouvez spécifier junit comme framework de test.*

![alt text](images/image-8.png)

### Observations

À noter :
1. Copilot devrait proposer d'écrire la réponse dans un nouveau fichier.
2. Vérifiez les tests générés et voyez s'ils correspondent au code que vous lisez.

## Étape 2 : Générer des tests pour `Number.js`

### Instructions
![alt text](images/image-9.png)

1. Ouvrez le fichier `Number.js` dans la solution `SumOfDigits`.
2. Appuyez sur `alt + I` avec le curseur sur le nom de la classe.
3. Tapez `/tests` et appuyez sur entrer.

### Observations

À noter :
1. Copilot devrait proposer d'écrire la réponse dans un nouveau fichier.
2. Vérifiez les tests générés et voyez s'ils correspondent au code que vous lisez.

## Étape 3 : Générer des tests pour `Number.js` en utilisant un modèle

### Instructions
*Ouvrez un nouveau chat*

1. Ouvrez le fichier `Number.js` dans le dossier `SumOfDigits`.
2. Appuyez sur `alt + I` avec le curseur sur le nom de la classe.
3. Tapez `/tests` et spécifiez que vous souhaitez utiliser le fichier `NumberTestTemplate1` comme modèle.

### Observations
1. Les résultats proposés devraient être différents de l'étape 2.
2. Refaites la même expérience mais avec `NumberTestTemplate2.js` ouvert et vérifiez la différence de réponse.

*Remarque : Copilot est bon pour reproduire des modèles. Lui donner des exemples sur lesquels travailler améliore la qualité de la sortie.*

## Étape 4 : Générer des tests dans le projet ComplexMethod

### Instructions

1. Générer un test pour la méthode `Execute` dans `SearchInDictionary.js`
2. Enregistrez le fichier généré sous ``SearchInDictionaryTestsStep1.js``
3. Remplacez l'appel `VerifyIpAddress` dans Execute par `VerifyIpAddressSimple`
4. Générer un test pour la méthode `Execute` dans `SearchInDictionary.js`
5. Comparez ``SearchInDictionaryTestsStep1.js`` avec le résultat précédent

### Observations

1. Il y a une limite au nombre de tests qui peuvent être générés
2. Vous avez besoin de petites méthodes pour générer des tests efficaces avec Copilot
3. Avec de nombreuses méthodes imbriquées, vous ne pouvez pas générer tous les tests unitaires
