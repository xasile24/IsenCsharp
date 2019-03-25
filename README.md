*Vusual Studio Code
* .Net Core SDK

#Préparation de la structure de la solution
* `mkdir Isen.DotNet`
* cd isen.dotnet
* `git init`
* `touch .gitignore` (ou le créer depuis VS) puis reccupéréer un gitignore spécifique à .Net Core
* Créer le repository sur git puis l'ajouter en temps que remote `git remote add origin https://github.com/xasile24/IsenCsharp.git`
* `git add .`
* `git commit -m "initial commit"`
* `git push origin master`

Créer un projet Console, dans un sous-dossier src:
* Créer le dossier src/ et naviguer dedans
* Dans le dossier src, créer Isen.DotNet.ConsoleApp et naviguer dedans
* Créer le projet ConsoleApp: `dotnet new console`

Créer le fichier solution
* Naviguer vers la racine du projet
* Créer le fichier .sln : `dotnet new sln`
* Ajouter les différents éléménts de la solution à ce projet (projet console + readme + gitignore):
** `dotnet sln add src/Isen.DotNet.ConsoleApp/`

Creer un dossier src/Isen.DotNet.Library et naviguer dedans.
Avecl la CLI .Net (dont l'interface en ligne de commande, que l'on utilise depuis le début), créer un projet de type 'librairie de classe':
`dotnet new classlib`
Référencer ce nouveau projet dans le fichier solution (.sln).
Depuis la racine : `dotnet sln add src/Isen.DotNet.Library`

Ajouter le projet Library comme référence du projet ConsoleApp.
* Naviguer dans le dossei du projet console
* `dotnet add reference ../Isen.DotNet.Library` 
 
# C#
Supprimer la classe autogénérée (ClassC1)


.
.
.




# Ajouter un projet de tests unitaires
* A la racine de la solution, créer un dossier 'tests' et un sous-dossier `Isen.DotNet.Library.Tests`
* Naviguer vers ce dossier
* `dotnet new xunit`
* Ajouter ce projet au sln, Depuis la racine: `dotnet sln add tests/Isen.DotNet.Library/Tests`
* Revenir dans le dossier de projet tests
* Referencier le projet Library dans le projet de test : `dotnet add reference ../../src/Isen.DotNet.Library`
* Renommer la classe générée automatiquement dans le projet de test et l'appeler 'MyCollectionTests'
* Coder un test de la méthode Add
* Executer `dotnet test`
* Coder les accesseurs indexeurs
* Coder méthodes 

#Après-midi
* On veut une classe générique à la place d'une classe capable de gérer seulement le type string
--- On rajoute donc <T> après la classe, quand on l'a définie et quand on l'appelle dans le test on note : `new Mycollection<string>()`
--- On remplace tout les string de la classe par T
* On renomme le fichier de Test pour préciser qu'il s'applique que au MyCollection<string> : `MyCollectionStringTest`
* Dupliquer `MyCollectionStringTest` en `MyCollectionCharTest` et adapter le code en conséquence

#Implementation l'interface IList<T>
* Indiquer l'implementation de l'heritage de l'interface IList<T>
* Utiliser l'ampoule de Omnisharp pour génerer automatiquement le using manquant et pour implementer les prototypes des méthodes de l'interface
* Coder ensuite les méthodes et leurs tests

# Manipulation des modèles
* Creer un nouveau dossier dans Library 'Persons' et une classe Person

#Apartée sur les type nullables
```csharp
     public void Why()
        {
            // Person est un type référence
            Persons person; // null
            person = new Persons(); // pas null
            person = null; // re null

            //int est un Value type
            // les types primitifs (bool, int, long, float ...)
            // sont des types valeur
            bool b; // true
            // b = null // interdit

            // bool? est un bool nulable (type référence)
            // bool? != bool
            // bool? = Nullable<bool>

            bool? nb = null; // null
            Nullable<bool> nbb; // null aussi
            var hasValue = nb.HasValue; // false
            nb = true;
            var val = nb.Value; // true

        }
```
* Fin de l'apartée

#Retour au modèle
* Une personne à 3 champs:
--- Prénom
--- Nom
--- Date de naissance

* On créer deux constructeurs (2 et 3 parametres)
* La version 2 parametres appelle celui à deux parametres puis complète