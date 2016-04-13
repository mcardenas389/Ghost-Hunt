# Ghost-Hunt

##Overview
Ghost Hunt is a 2D, turn based RPG created in Unity. It is the first major project that I've worked on in terms of game development, so I hope it turns out well! This README is largely for the purpose of stating the role of each class and the function of various assets needed in order for this project to function. Any classes or assets not mentioned in this file are likely to be phased out and most likely used for testing.

##Classes
**ChangeLaye.cs** - A simple script that will raise or lower a sprite's rendering layer depending on the position of the player character. i.e. if the player character is behind the sprite, the sprite will be on the rendering layer above the player character. 

**CombatManager.cs** - Controls the flow of combat using a state machine. It also communicates with other scripts that are involved with combat and is essentially the "director" of the combat scene.

**CombatUIController.cs** - Used to control the UI for combat.

**DialogueManager.cs** - Used to display dialogue boxes during interactions with NPC's as well as cutscenes.

**GameController.cs** - Stores global data that will be constantly refered to (e.g. player stats, inventory, equipment, etc.) and also handles saving and loading saved files.

**MainCamera.cs** - Controls camera movement and tracks player movement ensuring the player is always centered on the screen.

**PlayerController.cs** - Handles animation and movement of the player character.

**Spawner.cs** - Spawns a set prefab at a given position.
