using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backtomainmenu : MonoBehaviour
{
    // Start is called before the first frame update
  public void Backtothemainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Mainmenu");
       
    }
}
