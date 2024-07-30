# EvergreenOdyssey a 2D Game Platformer

Welcome to the 2D Game Platformer project! This repository contains the source code and assets for a simple 2D platformer game developed in Unity. The game features a player character that can navigate through various levels, interact with different objects, and face challenges.

## Features

- **Platformer Gameplay:** Classic 2D platformer mechanics with jumping, running, and obstacle navigation.
- **Level Generation:** Dynamic level generation with randomly selected tiles.
- **Player Interaction:** Basic player controls with collision detection.
- **Tile System:** Prefabs for different tiles that are used to create the game world.

![UI](https://github.com/ReuAzel181/2D-Game-Platformer/blob/main/rm-images/S1.png)
![UI](https://github.com/ReuAzel181/2D-Game-Platformer/blob/main/rm-images/S2.png)

## Getting Started

To get started with the 2D Game Platformer project, follow these steps:

### Prerequisites

- **Unity:** Ensure you have Unity installed (preferably the version used for this project).
- **Git:** Make sure you have Git installed to clone the repository.

### Cloning the Repository

Clone the repository to your local machine using the following command:

git clone https://github.com/ReuAzel181/2D-Game-Platformer.git

## Setting Up the Project

1. Open Unity Hub:
  - Launch Unity Hub and click on "Add" to add the cloned project folder.

2. Open the Project:
  - Select the project from Unity Hub and click on "Open" to load it in Unity Editor.

3. Play the Game:
  - Click the "Play" button in Unity to start the game and test the platformer mechanics.

## Game Components

### LevelGenerator.cs
- This script handles the procedural generation of game levels by spawning tiles based on player position. Key functionalities include:

 - Tile Prefabs: Array of tile prefabs used for level generation.
 - Player Detection: Spawns new tiles when the player approaches the edge of the current level.
 - Debugging: Logs the positions of tiles for troubleshooting.

## Player Controls
  - Basic player controls are implemented to allow movement and interaction with the game environment. The player can move left, right, and jump across platforms.

## Tile Prefabs
  - The game uses prefabricated tiles to build levels. Each tile prefab contains:
      Visual Elements: Graphics and animations for the tile.
      EndP Marker: A marker to indicate the end of the tile for proper placement during level generation.
    
**Contributing**
  - Feel free to contribute to the project by submitting issues or pull requests. We welcome any improvements or bug fixes!

**License**
  - This project is licensed under the MIT License. See the LICENSE file for more details.

### Contact
    For any questions or feedback, please reach out to:

**Author:** ReuAzel181

**Email:** reyuasel@gmail.com 

- Thank you for checking out the 2D Game Platformer project!
