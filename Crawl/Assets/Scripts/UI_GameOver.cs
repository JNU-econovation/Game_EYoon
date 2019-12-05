using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_GameOver : Singleton<UI_GameOver>
{
    public Text bestScore_Text;
    public Text score_Text;
    public Image backGround;
    public float alphaSpeed;
    public GameObject[] images;
    Color alpha;
    float time = 0;
    static float height;
    static int bestHeight;
    void Start()
    {
        alpha = backGround.color;
        bestHeight = Manager.Instance.GetBestHeight();
    }
    

    private void Awake()
    {
        height = Manager.Instance.GetHeight();
        if(height > bestHeight)
        {
            bestHeight = (int)height;
            PlayerPrefs.SetInt("HighScore", bestHeight);
        }
        PlayerPrefs.GetInt("HighScore", bestHeight);
        score_Text.text = ((int)height).ToString();
        bestScore_Text.text = bestHeight.ToString();
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
    }
}
