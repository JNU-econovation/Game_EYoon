using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Hazard
{
    GameObject fire;
    public float damage;
    float delay = 1.0f;
    public override void Function(GameObject window)
    {
        transform.position = new Vector3(window.transform.position.x, window.transform.position.y - 10.0f, window.transform.position.z);       
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        print(1);
        if(collider.gameObject.tag == "Player")
        {          
            StartCoroutine(Damage(collider.gameObject));
        }
    }

    IEnumerator Damage(GameObject player)
    {
        for(int i = 0; i < 5; i++)
        {
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
    }

}
