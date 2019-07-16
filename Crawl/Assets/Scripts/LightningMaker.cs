using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMaker : MonoBehaviour
{
    public GameObject warning;
    public GameObject lightning;
    int delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    IEnumerator LightningMake()
    {
        yield return new WaitForSeconds(delay);
    }
}
