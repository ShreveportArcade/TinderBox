using UnityEngine;
using System.Collections;
using System;

namespace TinderBox
{
    public static partial class TinderBoxAPI
    {
        static void _IsReady()
        {
            Instance.CallURL(MakeURL(IsReadyURL));
        }

        static void _GameOver()
        {
            Instance.CallURL(MakeURL(GameOverURL));
        }
        static readonly string BaseURL = "http://localhost:5000/api/games/";
        static readonly string IsReadyURL = "ready";
        static readonly string GameOverURL = "ended";

        static string MakeURL(string urlType)
        {
            string id = Instance.GameID;
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("The Game ID needs to be set in the Tinderbox Object.");
            }
            return BaseURL + id + "/" + urlType;
        }

        static KeyCode ControlsToKeyCode(Players player, Controls control)
        {
            switch (player)
            {
                case Players.Player1:
                    switch (control)
                    {
                        case Controls.Up:       return (KeyCode)KeyMapping.Player1Up;
                        case Controls.Down:     return (KeyCode)KeyMapping.Player1Down;
                        case Controls.Left:     return (KeyCode)KeyMapping.Player1Left;
                        case Controls.Right:    return (KeyCode)KeyMapping.Player1Right;
                        case Controls.Button1:  return (KeyCode)KeyMapping.Player1Button1;
                        case Controls.Button2:  return (KeyCode)KeyMapping.Player1Button2;
                        case Controls.Button3:  return (KeyCode)KeyMapping.Player1Button3;
                        case Controls.Button4:  return (KeyCode)KeyMapping.Player1Button4;
                        case Controls.Button5:  return (KeyCode)KeyMapping.Player1Button5;
                        case Controls.Start:    return (KeyCode)KeyMapping.Player1Start;
                        default: return KeyCode.None;
                    }
                case Players.Player2:
                      switch (control)
                    {
                        case Controls.Up:       return (KeyCode)KeyMapping.Player2Up;
                        case Controls.Down:     return (KeyCode)KeyMapping.Player2Down;
                        case Controls.Left:     return (KeyCode)KeyMapping.Player2Left;
                        case Controls.Right:    return (KeyCode)KeyMapping.Player2Right;
                        case Controls.Button1:  return (KeyCode)KeyMapping.Player2Button1;
                        case Controls.Button2:  return (KeyCode)KeyMapping.Player2Button2;
                        case Controls.Button3:  return (KeyCode)KeyMapping.Player2Button3;
                        case Controls.Button4:  return (KeyCode)KeyMapping.Player2Button4;
                        case Controls.Button5:  return (KeyCode)KeyMapping.Player2Button5;
                        case Controls.Start:    return (KeyCode)KeyMapping.Player2Start;
                        default: return KeyCode.None;
                    }
                case Players.Player3:
                    switch (control)
                    {
                        case Controls.Up:       return (KeyCode)KeyMapping.Player3Up;
                        case Controls.Down:     return (KeyCode)KeyMapping.Player3Down;
                        case Controls.Left:     return (KeyCode)KeyMapping.Player3Left;
                        case Controls.Right:    return (KeyCode)KeyMapping.Player3Right;
                        case Controls.Button1:  return (KeyCode)KeyMapping.Player3Button1;
                        case Controls.Button2:  return (KeyCode)KeyMapping.Player3Button2;
                        case Controls.Button3:  return (KeyCode)KeyMapping.Player3Button3;
                        case Controls.Button4:  return (KeyCode)KeyMapping.Player3Button4;
                        case Controls.Button5:  return (KeyCode)KeyMapping.Player3Button5;
                        case Controls.Start:    return (KeyCode)KeyMapping.Player3Start;
                        default: return KeyCode.None;
                    }
                case Players.Player4:
                    switch (control)
                    {
                        case Controls.Up:       return (KeyCode)KeyMapping.Player4Up;
                        case Controls.Down:     return (KeyCode)KeyMapping.Player4Down;
                        case Controls.Left:     return (KeyCode)KeyMapping.Player4Left;
                        case Controls.Right:    return (KeyCode)KeyMapping.Player4Right;
                        case Controls.Button1:  return (KeyCode)KeyMapping.Player4Button1;
                        case Controls.Button2:  return (KeyCode)KeyMapping.Player4Button2;
                        case Controls.Button3:  return (KeyCode)KeyMapping.Player4Button3;
                        case Controls.Button4:  return (KeyCode)KeyMapping.Player4Button4;
                        case Controls.Button5:  return (KeyCode)KeyMapping.Player4Button5;
                        case Controls.Start:    return (KeyCode)KeyMapping.Player4Start;
                        default: return KeyCode.None;
                    }
                default: return KeyCode.None;
            }
        }

        static Players IntToPlayer(int player)
        {
            switch (player)
            {
                case 0: return Players.Player1;
                case 1: return Players.Player2;
                case 2: return Players.Player3;
                case 3: return Players.Player4;
                case 4: throw new Exception("There are only 4 players.  Remember, the player count is zero-indexed.");
                default: throw new Exception("There are only 4 players.  You requested player #" + player + ".");
            }
        }

        static bool _ControlState(int player, Controls control)
        {
            return _ControlState(IntToPlayer(player), control);
        }
        static bool _ControlState(Players player, Controls control)
        {
            return Input.GetKey(ControlsToKeyCode(player, control));
        }

        static bool _ControlUp(int player, Controls control)
        {
            return _ControlUp(IntToPlayer(player), control);
        }
        static bool _ControlUp(Players player, Controls control)
        {
            return Input.GetKeyUp(ControlsToKeyCode(player, control));
        }

        static bool _ControlDown(int player, Controls control)
        {
            return _ControlDown(IntToPlayer(player), control);
        }
        static bool _ControlDown(Players player, Controls control)
        {
            return Input.GetKeyDown(ControlsToKeyCode(player, control));
        }

        //static void TestControls(bool heldDown = false)
        //{
        //    foreach (var value in System.Enum.GetValues(typeof(Controls)))
        //    {
        //        Controls control = (Controls)value;
        //        if (ControlDown(control))
        //        {
        //            Debug.Log("\"" + control.ToString() + "\" pressed.");
        //        }
        //        if (ControlUp(control))
        //        {
        //            Debug.Log("\"" + control.ToString() + "\" released.");
        //        }
        //        if (heldDown)
        //        {
        //            if (ControlState(control))
        //            {
        //                Debug.Log("\"" + control.ToString() + "\" held down.");
        //            }
        //        }
        //    }
        //}

        static TinderBoxObject _instance = null;
        static TinderBoxObject Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<TinderBoxObject>();
                }
                return _instance;
            }
        }
    }
    public class TinderBoxObject : MonoBehaviour
    {
        public string GameID = "";
        public void CallURL(string url)
        {
            WWW www = new WWW(url);
            StartCoroutine(WaitForURL(www));
        }

        IEnumerator WaitForURL(WWW www)
        {
            yield return www;
            if (www.error != null)
            {
                Debug.LogError(www.error);
            }
        }
    }
}
