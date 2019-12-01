using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PauseButton : MonoBehaviour
{
    public GameObject ui_pause;

    public void OnClick()
    {
        ui_pause.SetActive(true);
        LevelManager.Instance.Pause();
       // gameObject.SetActive(false);
    }
}
