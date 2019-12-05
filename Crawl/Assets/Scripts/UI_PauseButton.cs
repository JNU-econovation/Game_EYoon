using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PauseButton : MonoBehaviour
{
    public GameObject ui_pause;

    public void OnClick()
    {
        SoundManager.Instance.PlayClickSound();
        ui_pause.SetActive(true);
        LevelManager.Instance.Pause();
       // gameObject.SetActive(false);
    }
}
