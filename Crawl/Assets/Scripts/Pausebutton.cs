using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebutton : MonoBehaviour
{
    int zero = 0;
    public void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        
        print(Time.timeScale);
    }
 
}
