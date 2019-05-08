using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    Transform targetPosition;

    // Update is called once per frame
    void Update()
    {
        targetPosition = GameObject.FindWithTag("target").GetComponent<Transform>();

        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);




    }
}
