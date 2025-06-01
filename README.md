# Robot Serveur – Agent Intelligent avec Unity ML-Agents
Ce projet vise à entraîner un agent intelligent dans un environnement 3D de restaurant, en utilisant Unity ML-Agents et l’algorithme PPO (Proximal Policy Optimization). L’environnement est basé sur l’asset Fast Food Restaurant Kit, simulant un restaurant réaliste dans lequel un robot doit apprendre à naviguer.

####  ![image](https://github.com/user-attachments/assets/f8bca953-5f62-451e-99ee-81b2a04a5ab2)

## Objectif du projet
Développer un agent capable de :

 - Se déplacer intelligemment dans un restaurant 3D.

 - Rejoindre un "Target" (cube) apparaissant à différents emplacements à chaque épisode.

 - Éviter les obstacles (tables, murs, etc.).

 - Explorer toutes les zones accessibles du restaurant.

Ce système préfigure un cas réel où la "Target" sera remplacée par un client humain : l’agent devra alors détecter sa position, s’y diriger, et interagir correctement.

## Entraînement avec PPO
L’agent est entraîné à l’aide de l’algorithme PPO, configuré via un fichier YAML personnalisé. Certains des paramètres utilisés incluent :

- batch_size

- buffer_size

- epsilon

- learning_rate

- num_epoch

Ces réglages permettent un contrôle fin du comportement d’apprentissage.

## Architecture technique

### Interaction Unity ↔ ML-Agents
- Agent : gère l'observation, les récompenses, et les actions.

- Sensor : collecte les informations de l’environnement (Ray Perception, etc.).

- Actuator : exécute les décisions prises par le modèle.

- YAML config : définit les hyperparamètres pour l’entraînement PPO.

- Python ML-Agents : moteur d'entraînement externe qui communique avec Unity via socket.

## Fonctionnalités spécifiques
- Le "Target" est placé aléatoirement sur des points valides uniquement (évite les tables).

- L’agent apprend à éviter les collisions et à naviguer proprement dans l’environnement.

- La position du target change à chaque épisode, forçant une adaptation continue.

## Vers une application réelle
À terme, le projet évoluera pour que l’agent :

- Détecte dynamiquement un client réel via capteurs ou vision.

- Récupère la position du client via un serveur centralisé.

- Rejoigne automatiquement ce client comme un vrai serveur robotisé.

## Vue sur outils 

![image](https://github.com/user-attachments/assets/fdf9c4fd-b856-4d97-9e3f-bd71d5c52c18)


#### configue yaml

![image](https://github.com/user-attachments/assets/4843cabe-0cfa-4e3a-9dcc-a845634676cb)




