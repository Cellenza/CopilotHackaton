# Instructions de défi pour la commande `/explain`
## Étape 1 : Sur le fichier principal
### Instructions
![texte alternatif](images/image-1.png)
1. Ouvrez le fichier `Game.js`.
2. Appuyez sur `alt + I`.
3. Tapez `/explain` et appuyez sur entrée.

### Observations
![texte alternatif](images/image-2.png)
À noter :
1. Copilot a décrit toute la classe.
2. Vous pouvez accéder aux références utilisées dans l'invite de saisie. Notez que seul le fichier ouvert a été utilisé.
3. Vérifiez les explications et voyez si elles correspondent au code que vous lisez.

## Étape 2 : Sur plusieurs fichiers
### Instructions

*Ouvrez un nouveau chat.*

Vous pouvez demander à Copilot de prendre en compte d'autres fichiers en utilisant `#` dans le chat.

![texte alternatif](images/image-3.png)

### Observations

À noter :
1. Cette fois, seul le fichier spécifié a été pris en compte.
2. Comparez le résultat avec la réponse précédente qui n'utilisait que `Game.js`.

## Étape 3 : Exclusivement sur une section de code
### Instructions
*Ouvrez un nouveau chat.*
1. Ouvrez le fichier `Grid.js`.
2. Expliquez l'expression dans la méthode `isEmpty`.
3. Utilisez `#File:Grid.js:12` pour ne considérer que la ligne 31.
4. Sélectionnez la méthode `isFull` et tapez `/explain`.

### Observations

Vous pouvez sélectionner toute la classe, une méthode spécifique ou une ligne spécifique à expliquer.
