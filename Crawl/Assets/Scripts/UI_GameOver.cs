using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_GameOver : MonoBehaviour
{
    public Text bestScore;
    public Text score;
    public Image backGround;
    public float alphaSpeed;
    public GameObject[] images;
    Color alpha;
    float time = 0;
    static float height;
    static float bestHeight;
    void Start()
    {
        alpha = backGround.color;
    }
    /*
    private void OnEnable()
    {
        height = UIManager.Instance.GetHeight();
        bestHeight = UIManager.Instance.GetBestHeight();
        score.text = height.ToString();
        if(height >= bestHeight)
        {
            bestHeight = height;
            UIManager.Instance.SetBestHeight(height);
            bestScore.text = height.ToString();
        }

    }
    */
    public float GetBestHeight()
    {
        return bestHeight;
    }
    // Update is called once per frame
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
