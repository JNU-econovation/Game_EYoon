using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == player)
        {
            GameObject map = gameObject.transform.parent.gameObject;
            Destroy(map);
        }
    }
}
