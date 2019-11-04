using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UFO_bullet : MonoBehaviour
{
    float damage = 10;
    float speed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-speed,0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_AbilityManager.Instance.DecreaseHP(damage);
            Destroy(gameObject);
        }
    }
}
