# Limitations

### Choix de technologies

Lors de la conception du projet, nous avons choisi Unity et Photon pour son aspect multijoueur ainsi que la gestion de la communication entre joueurs. Lors de l’implémentation des composantes nécessaires de Photon, plusieurs problèmes ont été rencontrés. Nous avons été ambitieux en choisissant deux nouvelles technologies que personne dans le groupe de projet ne connaissait.

### Découverte des technologies

Avec les choix de nouvelles technologies, nous nous sommes basés sur plusieurs tutoriels très efficaces et bien faits. Ces derniers ont pris toute une journée à la réalisation et implémentation, mais étaient absolument cruciaux à la compréhension des mécaniques d’Unity et de Photon.

- [Build a 2D Platformer Game in Unity | Unity Beginner Tutorial](https://www.youtube.com/watch?v=Ii-scMenaOQ)

- [Unity Multiplayer Tutorial - Custom Matchmaking](https://www.youtube.com/watch?v=onDorc3Qfn0&t) 

### Inconstance des erreurs

Il était très difficile de trouver, réparer et reproduire des erreurs liées à Photon. Par exemple, le placement des chars lors de l’instanciation de Photon des objets joueurs. Cet aspect changeait de temps à autre sans aucune modification de notre part du code du jeu. C’est un problème qui n’est pas documenté en ligne et dont la source n’a jamais été découverte. 

### Conception solo/multijoueur

Pendant la conception nous avons séparé la partie réseau de la partie jeu. Cette décision a mené à deux parties de code complètement séparées. Donc, lors du développement du jeu, nous avons codé les chars sans penser à la partie réseau pendant que la gestion du lobby et des rooms était en parallèle. Nous avons sous-estimé le temps, la charge et la complexité de la fusion entre la logique du jeu et la partie réseau. Ceci étant dû à la simplicité apparente des tutoriels en ligne.

### Photon Pun 2
La version gratuite de Photon limite à 20 connexions simultanées sur le serveur. Ceci ne nous a pas posé de problème lors du développement, cette contrainte est à prendre en compte si le jeu est distribué à plus grande échelle.

### Conséquences

Dus aux grandes pertes de temps, nous avons pris la décision de continuer de débugguer les problèmes du multijoueur sur une branche appart ([combat](https://gitlab-etu.ing.he-arc.ch/isc/2022-23/niveau-3/3281-projet-p3-hes-ete/gr-2-tank/-/tree/combat )). Sur cette branche, se trouvent les derniers essais de réparer ou trouver des solutions pour les différentes erreurs rencontrées. Nous avons préparé une branche avec le jeu (en singleplayer) jouable sans la partie multijoueur ([final]()). Cette dernière contient les éléments artistiques de jeu comme les chars réellement dessinés ainsi que les bruitages  des attaques. 

# Perspectives

Nous pensons qu’en repassant sur le code du jeu entièrement et en implémentant les composantes de manière plus fluide et surtout harmonieuse (en utilisant des interfaces par exemple), il serait beaucoup plus évident de trouver les problèmes actuels.

De plus, dans le futur, il faudra prévoir la partie multijoueur en même temps de la partie locale. La fusion entre les deux n’étant vraiment pas facile ni évidente comme certains tutoriels suggèrent.

Une fois cette partie finie, il devrait être plutôt simple de rajouter des chars et des actions, le jeu et la conception étant faits dans cette optique. 