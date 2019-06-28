using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    int delay = 3;
    GameObject petrolWide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Petrol()
    {
        yield return new WaitForSeconds(delay);

    }
}
