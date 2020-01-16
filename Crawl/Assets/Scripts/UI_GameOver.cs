using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UI_GameOver : Singleton<UI_GameOver>
{
    public TextMeshPro bestScore_Text;
    public TextMeshPro score_Text;
    public Image backGround;
    public float alphaSpeed;
    public GameObject[] images;
    Color alpha;
    float time = 0;
    static float height;
    void Start()
    {
        Screen.SetResolution(720, 1280, true);
        alpha = backGround.color;
    }
    

    private void Awake()
    {
        height = PlayerPrefs.GetInt("Height");
        score_Text.text = ((int)height).ToString()+"m";
        bestScore_Text.text = PlayerPrefs.GetInt("HighScore").ToString() + "m";
    }
    
    void Update()
    {
        time += Time.deltaTime;
        alpha.a = Mathf.Lerp(alpha.a, 255, Time.deltaTime * alphaSpeed);
        backGround.color = alpha;
        if (time >= 1.5f)
        {
            for(int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
