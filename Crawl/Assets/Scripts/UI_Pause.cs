using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    public GameObject[] inGame_UIs;
    void OnEnable()
    {
        for (int i = 0;i< inGame_UIs.Length; i++)
        {
            inGame_UIs[i].SetActive(false);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < inGame_UIs.Length; i++)
        {
            inGame_UIs[i].SetActive(true);
        }
    }
    public void Onclick()
    {
        SoundManager.Instance.PlayClickSound();
        gameObject.SetActive(false);
        UIManager.Instance.panel.SetActive(true);
        UIManager.Instance.joyStick.SetActive(true);
        LevelManager.Instance.Resume();
    }
}
