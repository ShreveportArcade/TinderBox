using UnityEngine;
using System.Collections;
using System;

namespace TinderBox
{
    public static partial class TinderBoxAPI
    {
        static void _IsReady()
        {
            Debug.Log("IsReady");
            TinderBoxObject.Instance.CallURL(MakeURL(IsReadyURL));
        }

        static void _GameOver()
        {
            Debug.Log("GameOver");
            TinderBoxObject.Instance.CallURL(MakeURL(GameOverURL));
        }
        static readonly string BaseURL = "http://localhost/api/";
        static readonly string IsReadyURL = "game_ready";
        static readonly string GameOverURL = "game_ended";
        public static readonly float QuitCommandHoldLength = 5f;

        static string MakeURL(string urlType)
        {
            string id = TinderBoxObject.Instance.GameID;
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("The Game ID needs to be set in the Tinderbox Object.");
            }
            return BaseURL + urlType + "?game_id=" + id;
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
            if (player == Players.AnyPlayer)
            {
                return _ControlState(Players.Player1, control)
                    || _ControlState(Players.Player2, control)
                    || _ControlState(Players.Player3, control)
                    || _ControlState(Players.Player4, control);
            }
            return Input.GetKey(ControlsToKeyCode(player, control));
        }

        static bool _ControlUp(int player, Controls control)
        {
            return _ControlUp(IntToPlayer(player), control);
        }
        static bool _ControlUp(Players player, Controls control)
        {
            if (player == Players.AnyPlayer)
            {
                return _ControlUp(Players.Player1, control)
                    || _ControlUp(Players.Player2, control)
                    || _ControlUp(Players.Player3, control)
                    || _ControlUp(Players.Player4, control);
            }
            return Input.GetKeyUp(ControlsToKeyCode(player, control));
        }

        static bool _ControlDown(int player, Controls control)
        {
            return _ControlDown(IntToPlayer(player), control);
        }
        static bool _ControlDown(Players player, Controls control)
        {
            if (player == Players.AnyPlayer)
            {
                return _ControlDown(Players.Player1, control)
                    || _ControlDown(Players.Player2, control)
                    || _ControlDown(Players.Player3, control)
                    || _ControlDown(Players.Player4, control);
            }
            return Input.GetKeyDown(ControlsToKeyCode(player, control));
        }

        
    }
    public class TinderBoxObject : MonoBehaviour
    {

        static TinderBoxObject _instance = null;
        public static TinderBoxObject Instance
        {
            get
            {
                return _instance;
            }
        }

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
                //Debug.LogError(www.error);
            }
        }

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.Log("TinderBoxObject exists, destroying duplicate");
                GameObject.Destroy(gameObject);
            }
            
        }

        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            TinderBoxAPI.IsReady();
        }

        float quitTimer = 0;
        void Update()
        {
            // If any player holds Button 4 and 5 simultaneously for 5 seconds, the game ends.
            if (TinderBoxAPI.ControlState(Players.Player1, Controls.Button4) && TinderBoxAPI.ControlState(Players.Player1, Controls.Button5)
             || TinderBoxAPI.ControlState(Players.Player2, Controls.Button4) && TinderBoxAPI.ControlState(Players.Player2, Controls.Button5)
             || TinderBoxAPI.ControlState(Players.Player3, Controls.Button4) && TinderBoxAPI.ControlState(Players.Player3, Controls.Button5)
             || TinderBoxAPI.ControlState(Players.Player4, Controls.Button4) && TinderBoxAPI.ControlState(Players.Player4, Controls.Button5))
            {
                quitTimer += Time.deltaTime;
            } 
            else 
            {
                quitTimer = 0;
            }
            if (quitTimer > TinderBoxAPI.QuitCommandHoldLength) {
                Debug.Log("Quitting!");
                Application.Quit();
            }
        }


        void OnApplicationQuit() 
        {
            TinderBoxAPI.GameOver();
        }
    }
}
