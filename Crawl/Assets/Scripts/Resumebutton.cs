using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumebutton : MonoBehaviour
{
    // Start is called before the first frame update
 public void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 1;
    }
}
