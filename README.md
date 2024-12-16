# AMDDriverManager

**AMDDriverManager** est une application Windows développée en C# pour gérer et afficher les informations des pilotes AMD installés sur votre système. Cette application fournit des informations détaillées sur les versions des pilotes AMD à partir de diverses sources, y compris WMI, le registre Windows, et d'autres utilitaires. Elle permet également de désinstaller les pilotes AMD directement depuis l'interface graphique, avec des options pour redémarrer ou éteindre l'ordinateur après l'opération.

![Screen](https://i.imgur.com/sLi3qJ8.png)

- [X] Affichage des versions de pilotes AMD
- [X] Désinstallation des pilotes AMD
- [X] Redémarrage ou extinction de l'ordinateur après désinstallation

## Fonctionnalités

- Vérification des pilotes AMD installés via WMI et le registre Windows.
- Affichage de la version du pilote AMD dans l'interface graphique.
- Vérification de l'état du système pour conseiller l'utilisation en mode sans échec pour un nettoyage en toute sécurité.
- Désinstallation des pilotes AMD avec confirmation.
- Options pour redémarrer ou éteindre l'ordinateur après la désinstallation.

## Pré-requis

- Windows 10 ou supérieur
- .NET Framework 4.8.1 ou supérieur
- AMD GPU installé et drivers disponibles

## Utilisation

1. Lancer l'application pour afficher les versions des pilotes AMD installés.
2. Si vous souhaitez désinstaller les pilotes AMD, cliquez sur le bouton "Uninstall" et confirmez votre choix.
3. Vous aurez l'option de redémarrer ou d'éteindre l'ordinateur après la désinstallation.

### Commandes

- **`/uninstallrestart`** : Désinstalle le pilote AMD avec redémarrage.
- **`/uninstallnorestart`** : Désinstalle le pilote AMD sans redémarrage.
- **`/uninstallshutdown`** : Désinstalle le pilote AMD puis éteint l'ordinateur.

## Installation

1. Clonez ce dépôt sur votre machine locale :

   ```bash
   git clone https://github.com/o2Cloud-fr/AMDDriverManager.git

## Authors

- [@MyAlien](https://www.github.com/MyAlien)
- [@o2Cloud](https://www.github.com/o2Cloud-fr )

## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-o2Cloud-yellow.svg)]()


## Contributing

Contributions are always welcome!

See `contributing.md` for ways to get started.

Please adhere to this project's `code of conduct`.


## Feedback

If you have any feedback, please reach out to us at github@o2cloud.fr


## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://vcard.o2cloud.fr/)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/remi-simier-2b30142a1/)


## 🛠 Skills
C#


## License

[Apache-2.0 license](https://github.com/o2Cloud-fr/AMDDriverManager/blob/main/LICENSE)


![Logo](https://o2cloud.fr/logo/o2Cloud.png)


## Related

Here are some related projects

[Awesome README](https://github.com/o2Cloud-fr/AMDDriverManager/blob/main/README.md)


## Roadmap

- Additional browser support

- Add more integrations


## Support

For support, email github@o2cloud.fr or join our Slack channel.


## Tech Stack

## Used By

This project is used by the following companies:

- o2Cloud
- MyAlienTech

