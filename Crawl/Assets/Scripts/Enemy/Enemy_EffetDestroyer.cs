using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_EffetDestroyer : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
