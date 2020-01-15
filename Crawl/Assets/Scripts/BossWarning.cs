using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWarning : MonoBehaviour
{
    float r;
    float g;
    float b;
    Color textColor;
    // Start is called before the first frame update
    private void OnEnable()
    {
        textColor = GetComponentInChildren<Text>().color;
         r = GetComponent<Image>().color.r;
         g = GetComponent<Image>().color.g;
         b = GetComponent<Image>().color.b;
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        for(int i = 1; i <= 8; i++)
        {
            GetComponent<Image>().color = new Color(r, g, b, 0.1f*i );
            GetComponentInChildren<Text>().color = new Color(textColor.r, textColor.g, textColor.b, 0.1f * (i+2));
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds (3.0f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
 
}
