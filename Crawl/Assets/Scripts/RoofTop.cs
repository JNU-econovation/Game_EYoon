using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofTop : MonoBehaviour
{
    [SerializeField] GameObject service;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = service.GetComponent<LevelManager>().player;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider.gameObject);
        if(collider.gameObject == player)
        {
            print(1111);
            service.GetComponent<Manager>().GameComplete();
        }
    }
}
