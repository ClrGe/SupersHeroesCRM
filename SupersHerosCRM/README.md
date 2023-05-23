# L'API DES SUPERS HÉROS
## _Api pour l'application web de mise en relation entre supers héros et municipalités_

## Prérequis

- .NET 7.0

---
## Installation

```bash
git clone git@github.com:ClrGe/SupersHeroesCRM.git
cd SupersHeroesCRM
```
Modifier le fichier `appsettings.json` pour y mettre les informations de connexion à la base de données PostgreSQL.

```bash
dotnet restore
dotnet ef database update
dotnet run
```


---
## Stack technique

- ASP.NET 7.0
- PostgreSQL 13.3
