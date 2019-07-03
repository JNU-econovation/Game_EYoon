using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public int damage;
    Window window;

    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }

}
