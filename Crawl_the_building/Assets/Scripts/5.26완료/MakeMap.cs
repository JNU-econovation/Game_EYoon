using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    public Vector3 move;
    GameObject player;
    public GameObject service;
    public GameObject newMap;
    Vector3 spawnPosition;
    public float moveDistance;

    void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        move = new Vector3(0, moveDistance, 0);
        spawnPosition = transform.position + move;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == player)
        {
            Instantiate(newMap, spawnPosition, Quaternion.identity);           
        }

    }
}
