Cube Slide
This project is a clone of the popular mobile game "Cube Surfer," developed using the Unity game engine and C#. The main objective of the game is to collect cubes to raise the player's height and advance while avoiding obstacles.

Gameplay Screenshots
Here are some screenshots from the game:

A general view of the gameplay, showing the player collecting cubes.

The player navigating through obstacles or nearing the finish line.

Gameplay
The player automatically moves forward on the platform.

You can move the character by swiping left and right on the screen.

Collect the cubes on the path to increase the height of your stack.

You need to have a sufficient number of cubes to pass under the wall-like obstacles. If you don't have enough cubes, you lose the game.

Reach the finish line to complete the level.

Project Files and Scripts
Below are the C# scripts that manage the core mechanics of the project, along with their descriptions:

PlayerController.cs: Controls the player's core movements and interactions with game mechanics.

SwerveInput.cs & SwerveMovement.cs: These scripts detect the player's "swerve" input (sliding a finger across the screen) and handle the character's left-right movement accordingly.

CollectableCube.cs: Defines the behavior of the cubes that the player can collect.

Collector.cs: Manages the cube collection mechanic. It ensures that collected cubes are added to the stack beneath the player.

Obstacle.cs: Defines the behavior of obstacles. When the player hits an obstacle, the reduction of cubes is managed by this script.

CameraFollow.cs: Ensures the camera follows the player from a set distance.

GameManager.cs: Manages the overall game state (start, game over, restart) and the user interface (UI).

How to Run
Clone this repository to your local machine (git clone).

Open the project through Unity Hub.

Press the Play button in the Unity Editor to test the game.
