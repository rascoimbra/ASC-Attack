using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using UnityEngine.UI;

public class VerFoco : MonoBehaviour
{
    bool isPaused = false;

    void OnGUI()
    {
        if (isPaused)
            GUI.Label(new Rect(200, 200, 100, 60), "Game paused");
    }

    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }

   
}


