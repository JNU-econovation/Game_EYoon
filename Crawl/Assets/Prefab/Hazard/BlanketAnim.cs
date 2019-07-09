using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketAnim : MonoBehaviour
{

    public float lifeTime = 5.0f;

    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
