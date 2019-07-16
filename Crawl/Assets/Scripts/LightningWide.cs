using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWide : MonoBehaviour
{
    int damege = 20;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.GetComponent<Health>().DecreaseHP(damege);
        }
    }
}
