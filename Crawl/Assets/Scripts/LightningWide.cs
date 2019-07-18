using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWide : MonoBehaviour
{
    public float damege;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().DecreaseHP(damege);
        }
    }
}
