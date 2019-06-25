using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update

    public void ScoreUp(int number)
    {
        score += number;
        GetComponent<Text>().text = "Score: " + score;
    }
}
