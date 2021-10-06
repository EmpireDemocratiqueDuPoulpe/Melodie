![](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/blob/master/Melodie/wwwroot/images/melodie_black.png)

# Melodie
Melodie est un site web où un utilisateur inscrit peut créer des listes de lecture et y ajouter des musiques depuis des fichiers ou des liens. La lecture des musiques est assurée par [l'API Wavesurfer](https://wavesurfer-js.org/doc/). L'activation de JavaScript est donc indispensable.

***[Eng]** Melodie is a web site where a logged-in user can create playlists and add musics to them using a file or a link. The songs are played by the [Wavesurfer API](https://wavesurfer-js.org/doc/), so JavaScript is required.*

## Installation
Il suffit de télécharger le projet et de l'ouvrir avec un IDE <span>ASP</span>.NET Core 5.0 (Visual Studio, Rider, ...). La base de données du projet est une base MariaDB (v 10.5.8) exécutée en local. Il vous faudra [installer MariaDB](https://mariadb.org/download/) et importer le [fichier .sql](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/blob/master/Melodie/melodie_db.sql) fourni dans le repository. Si nécessaire, les paramètres  de connexion (hôte, port, nom de la bdd, ...) peuvent être modifié dans le fichier [appsettings.json](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/blob/master/Melodie/appsettings.json).

***[Eng]** You need to download the project and to open it using your IDE. This project run on <span>ASP</span>.NET Core 5.0 and the database is hosted locally with MariaDB 10.5.8. You can [install this version](https://mariadb.org/download/) or use your own installation and then import the [SQL file](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/blob/master/Melodie/melodie_db.sql) into it. If needed, you can change connection parameters in [appsettings.json](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/blob/master/Melodie/appsettings.json) file.*

## Bugs connus / Known bugs
- **[Suppression de playlist] -** Un bug apparu très tard qui survient lors de la suppression de playlist. Si l'utilisateur rentre le mauvais nom de playlist, le nom actuel de la playlist sera mis dans le champ "Name" du formulaire d'ajout de musique.

***[ENG]***
- ***[Playlist deletion] -** This is a weird bug found lately during the development. On the playlist deletion, if the user enters the wrong playlist name, the current playlist name will be set as value of the "Name" field used to add a music.*

## Comptes par défaut / Default accounts
Il existe déjà quelques comptes dans la base de données. Ils ont tous pour mots de passe **Supinfo123!** :
***[Eng]** There are already some default account you can use to log in. Their password is **Supinfo123!**:*
- Pierre-Ciseaux
- Captain Diabète
- Jean-Sébastien
- Jeanne d'Arc

## Fichiers mis en ligne / Supported musics files
Les fichiers mis en ligne depuis le site sont enregistrés dans le dossier [wwwroot/musics/](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/tree/master/Melodie/wwwroot/musics). Pour des raisons de droits d'auteur, aucune musique n'est incluse avec le projet. Les formats de fichiers supportés sont les suivants :
***[Eng]** Uploaded files are saved into the [wwwroot/musics/](https://github.com/EmpireDemocratiqueDuPoulpe/Melodie/tree/master/Melodie/wwwroot/musics) folder. Here is the list of supported audio files:*

> Le support d'un format dépend principalement du navigateur sur lequel il est lu.
> ***[Eng]** The file support depends mainly on the web browser you're using.*

| Extension | Type MIME                                                          |
|-----------|--------------------------------------------------------------------|
| wav       | audio/x-wav, audio/vnd.wave, audio/wav, audio/wave, audio/x-pn-wav |
| ogg / oga | application/ogg, audio/ogg                                         |
| caf       | audio/x-caf                                                        |
| flac      | audio/x-flac, audio/flac                                           |
| m4a       | audio/mp4                                                          |
| mp3       | audio/mpeg                                                         |
| wma       | video/x-ms-wma                                                     |
| au        | audio/basic                                                        |
| asf       | video/x-ms-asf, application/vnd.ms-asf                             |
| aac       | audio/aac                                                          |
| webm      | audio/webm                                                         |


