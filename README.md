# Tank vs Monsters
This is a simple game where the player controls a tank and must defend against waves of monsters.
The game was implemented using Unity version 2021.3.17f1 and C# scripting language.

## How to Play
### Controls
- Move and Rotate the tank: (up, down, left, right / w, a, s, d)
- Shoot: Key X
- Switch weapons: Q and E keys
### Gameplay
- The player's goal is to survive as long as possible against waves of monsters.
- Monsters will spawn randomly off-screen and move towards the player's tank.
- The player must destroy the monsters by shooting them with their tank's weapons.
- The player can switch between different weapons with the Q and E keys.
- The player must avoid colliding with the monsters, as this will damage the tank.

## Implementation

The game includes the following features:
- A tank with health, defense, and movement speed attributes
- Multiple weapon types with different appearances and damage
- Multiple types of monsters with different appearances, health, defense, speed, and damage
- Limit of 10 monsters on screen at a time
- Collision detection and damage calculation
- Random monster spawning off-screen
## Limitations and Potential Improvements
- The game currently does not have sound effects or music.
- The graphics could be improved to make the game more visually appealing.
## How to Run the Game
1. Clone the repository to your local machine.
2. Open the project in Unity.
3. Select the **GameScene** scene in the Assets/TankGame/Scenes folder.
4. Click the play button to start the game.

## TODO
- Need to create configs for Weapons and Enemy Damage
