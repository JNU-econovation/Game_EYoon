using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);

    }
    void Update()
    {
        transform.Translate(Vector3.up);
    }
}
