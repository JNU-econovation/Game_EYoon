using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Hazard
{
    public GameObject block;         
  
    public override void Function(GameObject window)
    {
        gameObject.transform.position = window.transform.position;              
        StartCoroutine(ThrowBlock());
    }
    IEnumerator ThrowBlock()
    {
       yield return new WaitForSeconds(2.0f);       
       float dx = player.transform.position.x - transform.position.x;
       float dy = player.transform.position.y - transform.position.y;
       float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;

       Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        if (transform.position.y > player.transform.position.y)
        {
            Instantiate(block, transform.position, Rotation);
        }
    }
}
