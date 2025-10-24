# tpApi - API de Prévisions Météo

API REST développée avec ASP.NET Core 9.0 pour gérer des prévisions météorologiques.

## Prérequis

Avant de pouvoir build et exécuter cette solution, vous devez avoir installé :

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) ou supérieur
- Un éditeur de code (Visual Studio, Visual Studio Code, Rider, etc.)

Pour vérifier que .NET est correctement installé :
```bash
dotnet --version
```

## Configuration

### Fichier d'environnement (.env)

L'application nécessite un fichier `.env` à la racine du projet pour configurer le token d'authentification API.

Créez un fichier `.env` à la racine du projet :
```bash
API_TOKEN=votre_token_secret_ici
```

**Important** : Le fichier `.env` est ignoré par Git pour des raisons de sécurité. Ne committez jamais ce fichier.

### Base de données

L'application utilise SQLite comme base de données. La connexion est configurée dans `appsettings.json` :
- Chemin de la base de données : `./Data/app.db`
- La base de données sera créée automatiquement au premier lancement de l'application

## Comment builder la solution

### 1. Restaurer les dépendances

Avant de builder, il faut restaurer tous les packages NuGet :

```bash
dotnet restore
```

ou simplement :

```bash
dotnet restore tpApi.sln
```

### 2. Builder la solution

Pour builder la solution en mode Debug :

```bash
dotnet build
```

Pour builder en mode Release :

```bash
dotnet build --configuration Release
```

### 3. Exécuter l'application

Pour lancer l'application en mode développement :

```bash
dotnet run --project tpApi/tpApi.csproj
```

L'application démarre et affiche les URLs d'écoute, généralement :
- `http://localhost:5000`
- `https://localhost:5001`

## Accéder à la documentation API (Swagger)

En mode développement, l'interface Swagger est disponible automatiquement :

1. Lancez l'application
2. Ouvrez votre navigateur à l'adresse : `http://localhost:5000` ou `https://localhost:5001`
3. L'interface Swagger UI s'affiche directement à la racine

La documentation Swagger permet de :
- Visualiser tous les endpoints disponibles
- Tester l'API directement depuis le navigateur
- Voir les modèles de données

## Structure de l'API

### Endpoints disponibles

L'API expose les endpoints suivants pour gérer les prévisions météo :

- `GET /forecasts` - Récupérer toutes les prévisions
- `GET /forecasts/{id}` - Récupérer une prévision spécifique
- `POST /forecasts` - Créer une nouvelle prévision
- `DELETE /forecasts/{id}` - Supprimer une prévision

### Authentification

Tous les endpoints nécessitent une authentification par token Bearer.

Pour utiliser l'API, ajoutez le header suivant à vos requêtes :
```
Authorization: Bearer votre_token_secret_ici
```

Le token doit correspondre à la valeur configurée dans la variable d'environnement `API_TOKEN`.

## Migrations de base de données

Les migrations Entity Framework Core sont déjà créées et se trouvent dans le dossier `tpApi/Migrations/`.

La base de données est créée automatiquement au démarrage de l'application grâce à `context.Database.EnsureCreated()` dans `Program.cs`.

### Créer une nouvelle migration (si nécessaire)

Si vous modifiez les modèles de données, vous pouvez créer une nouvelle migration :

```bash
dotnet ef migrations add NomDeLaMigration --project tpApi
```

### Appliquer les migrations manuellement

Si vous préférez appliquer les migrations manuellement :

```bash
dotnet ef database update --project tpApi
```

## Packages NuGet utilisés

- **Microsoft.EntityFrameworkCore.Sqlite** - Base de données SQLite
- **Microsoft.EntityFrameworkCore.Design** - Outils de migration
- **DotNetEnv** - Gestion des variables d'environnement
- **Swashbuckle.AspNetCore** - Documentation Swagger/OpenAPI
- **Microsoft.AspNetCore.OpenApi** - Support OpenAPI

## Commandes utiles

### Nettoyer la solution
```bash
dotnet clean
```

### Rebuild complet
```bash
dotnet clean && dotnet restore && dotnet build
```

### Lister les packages NuGet
```bash
dotnet list package
```

### Vérifier les mises à jour des packages
```bash
dotnet list package --outdated
```

## Dépannage

### La build échoue

1. Vérifiez que .NET 9.0 SDK est installé : `dotnet --version`
2. Supprimez les dossiers `bin/` et `obj/` puis relancez `dotnet restore` et `dotnet build`

### L'application retourne une erreur 500 au démarrage

Vérifiez que le fichier `.env` existe à la racine et contient bien la variable `API_TOKEN`.

### Erreur d'authentification (401/403)

Assurez-vous que le header `Authorization: Bearer <token>` est correctement configuré avec le token défini dans `.env`.

## Développement

### Structure du projet

```
tpApi/
├── tpApi.sln                    # Solution Visual Studio
└── tpApi/
    ├── Controllers/             # Contrôleurs API
    ├── Models/                  # Modèles de données
    ├── Data/                    # Contexte de base de données
    ├── Migrations/              # Migrations Entity Framework
    ├── Attributes/              # Attributs personnalisés (ex: authentification)
    ├── Program.cs               # Point d'entrée de l'application
    ├── appsettings.json         # Configuration de l'application
    └── tpApi.csproj            # Fichier de projet .NET
```

### Mode développement

En mode développement, l'application active automatiquement :
- Swagger UI à la racine
- Messages d'erreur détaillés
- Rechargement automatique (hot reload)

## Licence

Ce projet est un travail pratique (TP) à des fins éducatives.
