using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumebutton : MonoBehaviour
{
    
    // Start is called before the first frame update
 public void ResumeGame(LevelManager levelManager)
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        levelManager.player.GetComponent<PlayerMove>().forwardSpeed = levelManager.player.GetComponent<PlayerMove>().originforwardSpeed;

    }
}
