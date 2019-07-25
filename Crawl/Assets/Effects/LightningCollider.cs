using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollider : MonoBehaviour
{
    public float damege;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            collider.gameObject.GetComponent<Health>().DecreaseHP(damege);
        }
    }
}
