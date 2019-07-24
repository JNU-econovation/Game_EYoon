using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : Hazard
{
    Ray2D ray;
    RaycastHit2D rayHit;
    float distance = 90;
    
    public LayerMask playerLayerMask;
    
    private void Update()
    {
        ray = new Ray2D(transform.position, Vector2.down);
        rayHit = Physics2D.Raycast(transform.position, Vector2.down, distance, playerLayerMask);
       

        if (rayHit && rayHit.collider.gameObject.tag == "Player")
        {
            if (rayHit.collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            Manager.Instance.Gameover();
        }
    }
    public override void Function(GameObject window)
    {                
        HazardManager.Instance.WindowOpen(window);       
    }      

}
