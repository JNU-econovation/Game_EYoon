using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] int existTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        for(int i = 1; i < existTime; i++)
        {
            i++;
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }
}
