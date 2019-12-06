using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Button_Home : MonoBehaviour
{
    public void Onclick()
    {
        Manager.Instance.ResetCount();
        SceneManager.LoadScene("Main");
    }
}
