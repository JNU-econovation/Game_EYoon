using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SatelliteBullet : MonoBehaviour
{
    float damage = 10.0f;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_AbilityManager.Instance.DecreaseHP(damage);
           // Destroy(gameObject);
        }
    }
}
