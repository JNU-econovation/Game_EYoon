using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpawnerMover : MonoBehaviour
{
    public Transform targetTr;
    public float dist = 1.31f;
    void Update()
    {



        transform.position = new Vector3(360, targetTr.position.y - dist, 0);


    }
}
