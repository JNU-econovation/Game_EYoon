using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;
        if (touchCount > 0 || Input.GetKeyDown(KeyCode.A))
        {
            //SceneManager.LoadScene("InGame 1");
            Loading.LoadScene("InGame 1");
        }
    }
}
