using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Hazard
{
    GameObject fire;
    public float damage;
    float delay = 1.0f;
    private void OnEnable()
    {
        LevelManager.Instance.fireList.Add(gameObject);
    }
    public override void Function(GameObject window)
    {
        transform.position = new Vector3(window.transform.position.x, window.transform.position.y - 10.0f, window.transform.position.z);       
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if(collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
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
