using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
   [SerializeField] GameObject red;
   [SerializeField] GameObject black;
    float delay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorChange());
    }

    IEnumerator ColorChange()
    {
        while (true)
        {
            red.SetActive(true);
            black.SetActive(false);
            yield return new WaitForSeconds(delay);
            red.SetActive(false);
            black.SetActive(true);
            yield return new WaitForSeconds(delay);
        }
    }
}
