using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Vector3 move;
    GameObject temp;
    public GameObject newMap;
    Vector3 spawn;
    public float moveDistance;

    void Start()
    {
        move = new Vector3(0, moveDistance, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        spawn = collider.gameObject.transform.position + move;
        if (collider.gameObject.tag == "buildingMover")
        {
            
            temp = Instantiate(newMap, spawn, Quaternion.identity);
            temp.name = temp.name.Replace("(Clone)", "");
        }

    }
}
