using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebutton : MonoBehaviour
{
    
    public void PauseGame(LevelManager levelManager)
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        levelManager.player.GetComponent<PlayerMove>().forwardSpeed = 0;
        print(Time.timeScale);
    }
 
}
