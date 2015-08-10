# TinderBox
This is the API for the TinderBox arcade system.  Currently, this package is meant to support games made in Unity, although it is not required.

## Installation (for Unity)
1. Import the TinderBoxAPI.unitypackage file into your Unity project.
2. Add the TinderBoxObject prefab to your scene.
3. In the TinderBoxObject inspector, set the _Game ID_ field to your game's assigned ID.

## Usage
1. Add ```using Tinderbox;``` to your using statements in any files you want to access the API from.
2. After your game assets are loaded and the game is ready to play, you will need to call ```TinderBoxAPI.IsReady();```.  This will tell the launcher that the game is ready to present to the player.
3. When the game has ended, call ```TinderBoxAPI.GameOver();```.  This will return to the launcher screen.
4. Use ```TinderBoxAPI.ControlState()```, ```TinderBoxAPI.ControlUp()```, and ```TinderBoxAPI.ControlDown()``` to find the status of the arcade controls.  You will need to provide the player ID and the control name.
```c#

    public enum Players
    {
        Player1,
        Player2,
        Player3,
        Player4
    }

    public enum Controls
    {
        Up,
        Down,
        Left,
        Right,
        Button1,
        Button2,
        Button3,
        Button4,
        Button5,
        Start
    }
```