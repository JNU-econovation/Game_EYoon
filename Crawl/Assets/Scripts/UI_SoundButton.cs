using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SoundButton : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    bool onSound;
    public Image image;
    void Start()
    {
        onSound = true;
    }

    public void OnClick()
    {
        if (onSound) // 사운드 오프
        {
            image.sprite = soundOff;
            onSound = false;
            Camera.main.GetComponent<AudioSource>().Pause();
        }
        else // 사운드 온
        {
            image.sprite = soundOn;
            onSound = true;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
