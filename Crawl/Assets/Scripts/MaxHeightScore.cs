using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MaxHeightScore : MonoBehaviour
{
    [SerializeField] LevelManager LevelManager;
    // Start is called before the first frame update
   public void Start()
    {
        int height = (int)LevelManager.height;
        if (height > PlayerPrefs.GetInt("maxHeight"))
        {
            PlayerPrefs.SetInt("maxHeight", height);
            GetComponent<Text>().text = PlayerPrefs.GetInt("maxHeight").ToString();
        }
        else
            GetComponent<Text>().text = PlayerPrefs.GetInt("maxHeight").ToString();

    }


}
