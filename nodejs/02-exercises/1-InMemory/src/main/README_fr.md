# Spring Boot 3 + OpenAPI 3.0

## Exigences

## Lancer le projet

node app.js

# Scénario

Vous êtes un développeur travaillant sur un projet existant et ancien.

Le projet est une API RESTful qui fournit des opérations CRUD pour une liste d'étudiants.

L'API est construite en utilisant Spring Boot et utilise un stockage en mémoire pour stocker les données des étudiants.

Le projet a des tests pour les points de terminaison de l'API. Tous les tests réussissent.

Vous avez été chargé de changer le stockage en mémoire pour utiliser un mécanisme de stockage persistant.

## Tâches

1. Intégrer la base de données H2 avec les bibliothèques Hibernate pour stocker la liste des étudiants

2. Mettre à jour le point de terminaison d'ajout existant pour enregistrer les données des étudiants dans la base de données

3. Mettre à jour le point de terminaison de récupération existant pour récupérer les données des étudiants de la base de données

4. Mettre à jour le point de terminaison de mise à jour existant pour mettre à jour les données des étudiants dans la base de données

5. Mettre à jour le point de terminaison de suppression existant pour supprimer les données des étudiants de la base de données

6. S'assurer que tous les tests existants réussissent toujours après les modifications

8. Demander à copilot d'aider avec le message de commit

9. Demander à copilot de documenter les points de terminaison de l'API dans le code source

## Contraintes

- Ne pas changer les tests existants, ils doivent toujours réussir après les modifications avec des modifications minimales

- Ne pas changer les points de terminaison de l'API existants

## Critères d'acceptation

- Le point de terminaison d'ajout existant enregistre les données des étudiants dans la base de données

- Le point de terminaison de récupération existant récupère les données des étudiants de la base de données

- Le point de terminaison de mise à jour existant met à jour les données des étudiants dans la base de données

- Le point de terminaison de suppression existant supprime les données des étudiants de la base de données

- Tous les tests existants réussissent toujours après les modifications

- Le message de commit suit la convention : `feat: implement database integration using Hibernate`

## Ressources

- [Hibernate](https://hibernate.org/)
- [H2 Database](https://www.h2database.com/html/main.html)

# Classe Étudiant

```
public class Student
{
  private long id;
  private String firstName;
  private String lastName;
}
```

## Points de terminaison de l'API

### Ajouter un étudiant

- URL : `/api/students`
- Méthode : `POST`
- Corps de la requête :

```json
{
    "firstName": "John Doe",
    "lastName": 25
}
```

- Corps de la réponse :

```json
{
    "id": 1,
    "firstName": "John Doe",
    "lastName": 25
}
```

### Récupérer un étudiant

- URL : `/api/students/{id}`
- Méthode : `GET`

- Corps de la réponse :

```json
{
    "id": 1,
    "firstName": "John Doe",
    "lastName": 25
}
```

### Mettre à jour un étudiant

- URL : `/api/students/{id}`
- Méthode : `PUT`
- Corps de la requête :

```json
{
    "firstName": "John Doe",
    "lastName": 25
}
```

- Corps de la réponse :

```json
{
    "id": 1,
    "firstName": "John Doe",
    "lastName": 25
}
```

### Supprimer un étudiant

- URL : `/api/students/{id}`
- Méthode : `DELETE`
