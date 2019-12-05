using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Main : MonoBehaviour
{
    int rand;
    int i = 700;
    int j = 300;
    public Text tapToStart;
    public GameObject[] dolphin;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 2);
        StartCoroutine(OnandOffText());
      //  StartCoroutine(SpawnDolphin());
    }
    IEnumerator SpawnDolphin()
    {
        while (true)
        {
            GameObject temp = Instantiate(dolphin[0]);
            temp.transform.position = new Vector3(360 + i, 640 + 70, 0);
            i -= 200;
            if (i < 0)
                i = 750;
            yield return new WaitForSeconds(3f);
            GameObject temp1 = Instantiate(dolphin[1]);
            temp1.transform.position = new Vector3(i, 640 + 100, 0);
            j -= 200;
            if (j < 0)
                j = 700;
        }
    }

    IEnumerator OnandOffText()
    {
        while (true)
        {
            bool isActive = tapToStart.gameObject.activeSelf;
            if (isActive)
            {
                tapToStart.gameObject.SetActive(false);
            }
            else
            {
                tapToStart.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
