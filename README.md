# TinderBox API
This is the API for the TinderBox arcade system.  Currently, this package is meant to support games made in Unity, although it is not required.

## Installation (for Unity)
1. Import the TinderBoxAPI.unitypackage file into your Unity project.
2. Add the TinderBoxObject prefab to your scene.
3. In the TinderBoxObject inspector, set the **Game ID** field to your game's assigned ID, and the **Host** field to the current arcade cabinet's address.

## Usage (for Unity)
1. Add `using Tinderbox;` to your using statements in any files you want to access the API from.
2. After your game assets are loaded and the game is ready to play, you will need to call `TinderBoxAPI.IsReady();`.  This will tell the launcher that the game is ready to present to the player.
3. When the game has ended, call `TinderBoxAPI.GameOver();`.  This will return to the launcher screen.
4. Use `TinderBoxAPI.ControlState()`, `TinderBoxAPI.ControlUp()`, and `TinderBoxAPI.ControlDown()` to find the status of the arcade controls.  You will need to provide the player ID and the control name, listed below: 
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


## Usage (general)
1. You will need to make http requests.  The URL structure is: **http://** + *host* + **/api/games/** + *game id* + **/** + *command*
2. After your game assets are loaded and the game is ready to play, you will need to make a request using the **ready** command.  This will tell the launcher that the game is ready to present to the player.
3. When the game has ended, make a request using the **ended** command.  This will return to the launcher screen.
4. Map your controls to a receive keyboard inputs.  Use these mappings:

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
Start:      Return

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
Start:      T

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
Start:      [ (left bracket)

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
Start:      0
