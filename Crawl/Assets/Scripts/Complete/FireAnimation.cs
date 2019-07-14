using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAnimation : Hazard
{
    public float damage;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");                
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        //화상피해
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
                
            Function();                               
        }
        
    }

    void Function()
    {                     
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {            
        for(int i = 0; i < 5; i++)
        {
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(1.0f);
        }       
    }

    public override void Function(GameObject window)
    {
        
    }
}
