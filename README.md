# TinderBox API
This is Shreveport Arcade's fork of the API for the TinderBox arcade system by our good friends over at [Flint & Tinder Studios](http://www.flintandtinderstudios.com/).  For information and discussion on the TinderBox, please visit https://www.progfrog.co/projects/34/log (coming soon - instructions for uploading your game and getting your Game ID).  This API is designed around Unity, but if your game can run on Linux you should be able to integrate it manually also (see below for details).

![controls](http://i.imgur.com/zgx0GoY.png)

## Workflow ##
1. When a player chooses your game, our launcher will run your game's executable in a background process.
1. Once your game has loaded its assets and is ready to play, it should send a **game_ready** command to the launcher (see below).
1. The launcher will present your game fullscreen at 1920x1080 resolution.
1. After the player has completed a game and is out of continues (or lets your "continue playing?" timer run out), your game should send a **game_ended** command to bring the launcher back to the front.
1. Do not exit your game - our launcher will kill your process when it's ready.

## Installation (for Unity)
1. Import the TinderBoxAPI.unitypackage file into your Unity project.
1. Add the TinderBoxObject prefab to your initial scene.
1. In the TinderBoxObject inspector, set the **Game ID** field to your game's assigned ID.
1. In your game's Player Settings, set "Display Resolution Dialog" to "Hidden By Default".

## Usage (for Unity)
1. Add `using TinderBox;` to your using statements in any files you want to access the API from.
2. Observe the workflow at the top of this page, using the API commands `TinderBoxAPI.IsReady()` and `TinderBoxAPI.GameOver()`.
3. Use `TinderBoxAPI.ControlState()`, `TinderBoxAPI.ControlUp()`, and `TinderBoxAPI.ControlDown()` to find the status of the arcade controls.  You will need to provide the player ID and the control name, listed below: 
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
        Button5
    }
```

## Usage (non-Unity)
1. To give the launcher a command, send an HTTP GET request to: http://localhost/api/{command}?game_id={your-game-id}
1. Observe the workflow at the top of this page, using the API commands **game_ready** and **game_ended**.
1. Map your controls to a receive keyboard inputs.  Use these mappings:

```
Player 1
--------
Up:         Up arrow  
Down:       Down arrow  
Left:       Left arrow  
Right:      Right arrow  
Button 1:   M
Button 2:   , (comma)
Button 3:   . (period)
Button 4:   / (slash)
Button 5:   Right shift

Player 2
--------
Up:         W 
Down:       S  
Left:       A  
Right:      D  
Button 1:   V
Button 2:   G
Button 3:   Y
Button 4:   C
Button 5:   F

Player 3
--------
Up:         U 
Down:       J  
Left:       H  
Right:      K  
Button 1:   O
Button 2:   P
Button 3:   L
Button 4:   ; (semicolon)
Button 5:   ' (single quote)

Player 4
--------
Up:         2 
Down:       3  
Left:       1  
Right:      4  
Button 1:   5
Button 2:   6
Button 3:   7
Button 4:   8
Button 5:   9
```