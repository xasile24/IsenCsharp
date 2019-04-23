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

### Migration vers une entité

* Ajouter un champ Id (int) et Name (string)
* Pour le champ name on va déclarer explocotement le champs de backup privé _name

### Modele city
* Créer dans Models une classe city, avec Id et Name
* Name + ZipCode
* Dans Person ajouter une relation avec City : un champ BornIn de type City

### Refactoring
* Déplacer Id et Name vers une classe de base, abstraite : `_BaseModel`
* Faire dériver City et Person de _BaseModel.
Noter les champs Id et Name comme des override (puisque les champs sont virtuels dans BaseModel).

### Display 
* Implémenter un mode d'affichage de base (string), overrridable.
* l'utiliser dans `ToString()`
* Completer ce mécanisme afin d'ajouter le ZipCode à l'affichage des City
* Puis reprendre l'affichage d'une Person.

### Création de Repositories
* `But : Avoir une classe de base qui s'occupe des connexions avec la base de données et qui définie les méthodes de bases`
* Créer cette arbo :
[Library]
    /Repositories
    /Repositories/Base (repo abstrait)
    /Repositories/Interfaces (base et interfaces spécifiques)
    /Repositories/InMemory (implementation InMemory)

* Implementer une liste test (ModelCollection)

### Single
* Ajouter deux méthodes Single : recherche par Id et recherche par Name
* Ecrire des tests unitaires pour tester ces deux méthodes Single.

### Update
* Créer une méthode qui permette e renvoyer le premier Id dispo (max + 1)
* Créer une méthode Update qui gère automatiquement les créations des nouvelles entités, ou les mises à jours d'entités existantes
* Créer une méthode ``SaveChanges()`` qui permet un mécanisme de transaction (décider de sauver les changements ou non) via une copie du contexte

### Delete

Créer une méthode de ``Delete()`` d'une entité, qui utilise le mécanisme de transaction

### Listes

* Créer une méthode ``getAll`` qui renvoie toutes les entités du contexte
* Créer une méthode ``Find()è`qui prend comme paramètre un prédicat de recherche et qui sera passer sou sforme de lambda expression (méthode anonyme)



* A ce stade, nous avons couvert toutes les opérations de CRUD:
- C = Create
- R = Read
- U = Update
- D = Delete

## Refactoring: généralisation du repo

* Dans le dossier basee, créer ``BaseInMemoryRepository``
* Déplacer toutes les méthodes de CityRepository vers BaseInMemoryRepository et les adapter en generic.

### Extraction d'interface
* Dans le dossier Interfaces, créer ``IBaseRepository`` et y rappatrier toutes les signatures des opérations de CRUD
* Créer une interfaec ``ICityRepository`` qui implémente ``IBaseRepository``, sans ajouter de méthode
* ``InMemoryCityRepositpry`` devra implémenter cette interface.

### TD : Refaire la même chose pour PersonRepository
* Créer l'interface IPersonRepository
* Créer InMemoryPersonRepository
* Créer InMemoryPersonRepoTest en dupliquant l'autre

### Composition / Injection de Repositories
* Dans InMemoryPersonRepository, ajouter un constructeur, qui prend comme paramètre une interface de ICityRepository.
* La classe ``PersonRepository`` nécessite d'avoir une instance de ``ICityRepository`` pour fonctionner. On dit qu'elle a une dépendance sur cette classe.
* Cette dépendance est déclérée dans son constructeur.
* Ce design pattern d'appelle : 
- Pattern d'Injecttion de Dependance
- aka IoC : Inversion of Control
- aka DI : Dependency Injection

### Relations réciproques
* Nous avons la classe de modèle `Person` qui a un champ de type `city` dans sa propriété `BornIn`
* En terme de verbatim OOP, c'est une relation par composition (une ckasse a un champ dont le type est une autre classe), par opposition à une relation par héritage.
* En thermes de verbatim de Base de données relationelles, c'est une relation `one-to-many`, puisque une personne a une ville, mais une ville a potentiellement plusieurs personnes.
* On peut donc, au niveau de `City`, ajouter une propriété de liste de personnes qui serait donc la relation réciproque de `Person.BornIn`
* Attention cependant, même si on ajoute cette relation, elle ne v a pas se remplir toute seule


# Ajout d'un projet ASP.NET MVC (Cora)

## Ajout du projet depuis le template de la CLI .Net Core

* Depuis le dossier src, ajouter un dossier `Isen.DotNet.Web`
* Naviguer dans ce dossier puis `dotnet new mvc`
* Directement : `dotnet run` et ouvrir http://localhost:5000

* Ajouter le projet Library en référence au projet web : `dotnet add reference ../Isen.DotNet.Library`

* Revenir à la racine et ajouter ce projet à la solution : `dotnet sln add src/Isen.DotNet.Web`


## Anatomie d'un projet MVC

le schéma (routing) par défaut des urls d'un projet MVC est:
https://localhost:5001/[Vue]/[Action][?param=value&param2=value2]

OU

https://localhost:5001/[Vue]/[Action][?param=value....]

Ce schéma peut être complété / modifié / reécrit selon les besoins

* Dossier `/wwwroot` : contient essentiellement les assets de l'application, soit les images, les css (scss/sass) et les js (ou typescript), ainsi que les copies locales des librairies utilisées (Bootstrap4, jQuery...). Golbalement, tout ce qui doit être chargé côté navigateur.

* Dossier `/Views` : contient des Fichier `.cshtml`, ce sont des templates HTML écrit avec la syntaxe de templating *Razor*. Razor utilise plus ou moins la syntaxe du C#.
    
    * Chaque dossier (à part Shared) correspond à un contrôleur. Exemple : le dossier Home contient les vues accessible via https://localhost:5001/Home et chaques vue à un controller correspondant (que l'on verra plus tard) et on peut avoir plusieurs vues par contrôleur. Ex : `Privacy` et `Index` sont 2 vues / actions du contrôleur `Home`.

    * Chaque fichier correspond à une action. Exemple : Dans Home, le fichier `Privacy.cshtml` correspong à l'url `https://localhost:5001/Home/Privacy` 

    * L'action `Index` est l'action par défaut. Donc si l'url ne précise pas d'action dans ses segments, c'est l'action Index qui est appelée.

    * `/Shared/_Layout.cshtml` contient le template global dans lequel les vues vont s'insérer.

    Les chemins en `~/` correspondent à `/wwwroot` .

    Les librairies (JS / CSS) sont chargées localement en environnement de dev, et depuis un serveur CND, en environnement de prod.

    Les CSS sont chargés dans le `<head>` de la page, les JS quant à eux tout à la fin du `<body>`.

* Dossier `/Controllers` :  Classes C#, dont le but est :
    * Sens Serveur > Client : de prendre des data dans un modèle, et les injecter dans la vue/action correspondante
    * Sens Client > Serveur : de répondre aux requêtes (GET, POST, etc...)
    
    Le nommage des classes de controller est normalisé :
        `NomDeLaVueController` (Ex : `HomeController`)
    Le nommage des méthodes est également normalisé, et correspond aux actions. (Ex : `HomeController.Privacy()` ou `HomeController.Index()`)

* Dossier `/Models` : ce dosseir contient des ViewModels. Donc des classes C# uniquement constituées de champs (pas de logique, pas de méthodes). On appelle se genre de classes des POCO (Plain Old C# object), ou encore des Value Objects

    Par opposition aux classes de Model métier (Person, City), les ViewModel ont pour but d'avoir uniquement les champs strictement nécessaires à l'affichage.
    
    Ex : Si on affiche une liste des `Person`, avec uniquement nom et prénom, on créera un `PersonViewModel` avec `FirstName` et `LastName`, mais on ne mettera pas `BornIn` ni `DateOfBirth`. le but étant d'avoir un objet aussi léger que possible, pour minimiser les transferts.

* Fichier `/Startup.cs` : Configuration des injections de dépendances, des services utilisés par l'application (repositories, librairies, loggers, etc...)

* Fichier `/Program.cs` : point d'entrée de l'application. Depuis .Net Core et ASP.NET MVC Core, une application web est en fait une application console.

    Ce point d'entrée lance la configuration des services, puis lance le serveur web embarqué (Kestrel).

* Fichier `/appsettings.json` : Ce sont les settings de l'application. La chaîne de connexion à une base de données se retrouvera là-dedans.

# Ajout de vues

## Ajouter des éléments de menu

Le menu de navigation utilise les éléments et classes issues du framework Bootstrap4. Utiliser les élément sde ce fraùework pour ajouter une navigation en menus déroulants.
Doc : https://getbootstrap.com/docs/4.1/getting-started/introduction/

Ajouter la navigation suivante dans le fichier `_Layout.cshtml`: 
* Villes (pas une page, juste un noeud de menu)
    * Toutes (afficher la liste des villes)
        `https://localhost:5001/City/[Index]`
    * Ajouter ... (Afficher un formulaire de saisie vide)
        `https://localhost:5001/City/Edit`

Lorsqu'on cliquera sur une ville dans la liste, on pourra l'éditer avec une url du type `https://localhost:5001/City/Edit/2` qui appellera en fait la vue "Ajouter", qui servira aussi bien à la création qu'à la modification.


## Ajouter le contrôleur CityController

Dans le dossier des contrôleurs, créer `CityController.cs` et ajouter les méthodes correspondant aux 2 actions prévues (Index et Edit)

## Ajouter les vues correspondates

### Les vues vides
Dupliquer le dossier Home et le nommer City, viser et adapter les vues : Enlever tout le Html existant et mettre juste 1 titre dans chaques views

### Maquette du tableau
Utiliser les élements de tabeaux en layout Bootstrap issus de cette doc : https://getbootstrap.com/docs/4.1/content/tables/

### Injection d'un modèele dans la vue liste / tableau

Dans le controlleur de `City`, instancier le repository de `City`.
Récupérer la liste des cilles, et la passer à la vue.

dans la vue City/Index.cshtml, préciser le type du model de syntaxe Razor avec IEnumerable<City>, avec les directives @using et @model

Itérer le bloc html <tr></tr> avec une directive @foreach

Ajouter les atributs de consterction d'url sur les deux liens '<a>' (Modifer, Supprimer)