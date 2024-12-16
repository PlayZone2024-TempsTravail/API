# Playzone 2024 - Gestion du temps et du budget - Partie back

[👉 Accédez à la partie Backend](https://github.com/PlayZone2024/Front)

## Description

Ce projet a permis de digitaliser et d’automatiser avec succès la gestion des projets, des budgets et des prestations internes, améliorant ainsi l’efficacité opérationnelle de l’institut. La solution logicielle développée offre désormais une gestion transparente des coûts, des prestations et des rapports financiers, répondant pleinement aux attentes des organismes subsidiants et du secrétariat social. Voici les principaux objectifs du projet :

- **Automatiser la gestion des projets et tâches internes** : centralisation des projets, suivi des prestations, et imputation des coûts.
- **Optimiser le suivi des budgets** : prévision et suivi en temps réel des coûts, avec extraction facilitée pour les rapports aux organismes subsidiants.
- **Simplifier la gestion des prestations internes** : encodage des prestations, centralisation RH, affectation des coûts aux projets, et automatisation des données pour le pointage RH.

---

## Prérequis

Avant de commencer, assurez-vous d'avoir installé les éléments suivants :

- [.NET](https://dotnet.microsoft.com/en-us/download) version 8.0

Nous avons utilisé la librairie [DinkToPdf](https://github.com/rdvojmoc/DinkToPdf) qui exploite [libwkhtmltox](https://wkhtmltopdf.org/libwkhtmltox/) dont le binaire est requis pour la génération de pdf et devras être placé dans le dossier Playzone.Razor/Lib. Il est peut-être téléchargé [ici](https://github.com/rdvojmoc/DinkToPdf/tree/master/v0.12.4/64%20bit)

### Windows
c'est libwkhtmltox.dll qui requiert [Microsoft Visual C++ 2015-2022 Redistributable (x64)](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170)

### Linux (Debian 12)
c'est libwkhtmltox.so qui requiert certains packages
```bash
sudo apt update
sudo apt install libx11-6 libxext6 libxrender1 libfreetype6 libfontconfig1 zlib1g libc6 libstdc++6 libgcc1
```

_les versions données sont celles utilisées lors du développement, il est possible que des versions plus récentes soient compatibles_

## Installation et démarrage

```bash
git clone https://github.com/PlayZone2024/API.git
cd API
dotnet run --project PlayZone.API
```

_il est nécéssaire d'ajuster les informations de la base de données dans PlayZone2024/appsettings.json et de l'initialiser avec les scripts situé dans InitDB/_

---

## Contributeurs

Ce projet n'aurait pas été possible sans l'implication et le travail de toutes les personnes suivantes. Merci à chacun pour sa contribution unique et précieuse.

### Business Analysts

Ces personnes ont contribué à l'analyse des besoins, la définition des fonctionnalités, et la documentation des processus métiers :

- **Alexandra Ercoli Caller** - [LinkedIn](https://www.linkedin.com/in/alexandra-ercoli-caller/)
- **Aurélie Mbiye Mujinga** - [LinkedIn](https://www.linkedin.com/in/aurélie-mbiye-mujinga/)
- **Merve Sehirli Nasir** - [LinkedIn](https://www.linkedin.com/in/merve-sehirli-nasir-phd/)
- **Etienne Botton** - [LinkedIn](https://www.linkedin.com/in/etienne-botton-a9731817/)

### Développeurs

Ces personnes ont conçu, développé et testé les fonctionnalités de ce projet :

- **Dylan Radelet** -  _Front_ - [LinkedIn](https://www.linkedin.com/in/dylan-radelet/)
- **Eva Maudoux** - _Front_ - [LinkedIn](https://www.linkedin.com/in/evamaudoux/)
- **Jérôme Tcherepachin** - _Back & Front_ - [LinkedIn](https://www.linkedin.com/in/jérôme-tchérépachin-45b148323/)
- **Louis Delleur** - _Back & Front_ - [LinkedIn](https://www.linkedin.com/in/louis-delleur/)
- **Louis Patigny** - _Back & Front_ - [LinkedIn](https://www.linkedin.com/in/louispatigny/)
- **Sébastien Dendal** - _Back_ - [LinkedIn](https://www.linkedin.com/in/sebastiendendal/)
- **Steven Hanse** - _Back_ - [LinkedIn](https://www.linkedin.com/in/steven-hanse/)

### Administrateurs Système

Ces personnes ont assuré la gestion des serveurs, la mise en place des environnements, et le bon fonctionnement des infrastructures :

- **Dylan Olivier** - [LinkedIn](https://www.linkedin.com/in/dylan-olivier/)
- **Florent Descamp** - [LinkedIn](https://www.linkedin.com/in/florent-descamps/)
- **Ilyas Hadji** - [LinkedIn](https://www.linkedin.com/in/ilyas-hadji/)
- **Jonathan Mathieu** - [LinkedIn](https://www.linkedin.com/in/jonathan-mathieu-180050329)

---

## Remerciements Spéciaux

Nous souhaitons également remercier toutes les autres personnes qui ont contribué directement ou indirectement au succès de ce projet.
