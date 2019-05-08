using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float sideMove;
    public float forwardSpeed;
    public float itemDelay;
    public float moveDistance;
    public float weatherDelay;
    public float slowSpeed;
    public int HP;
    public int bulletAmount;
    public int heatDamage;
    int upDown = 1;

  
    void Update()
    {
        transform.Translate(0, forwardSpeed, 0);


        if (Input.GetKey(KeyCode.D) )
        {
            transform.Translate(sideMove*Time.deltaTime, 0, 0);
            
          
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-sideMove*Time.deltaTime, 0, 0);
           
        }
     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forwardSpeed = -forwardSpeed;
            upDown = upDown + 1;

        }

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "buildingMoverDown"&& upDown % 2 == 0)
        {
            other.transform.parent.Translate(0, -moveDistance, 0);
            
        }
        else if(other.gameObject.tag == "buildingMover"&& upDown % 2 == 1)
        {
            other.transform.parent.Translate(0, moveDistance, 0);
        }
        if(other.gameObject.tag == "Hazards")
        {
            HP = HP - heatDamage;
        }
        if(other.gameObject.tag == "Cleaner")
        {
            transform.Translate(0,-forwardSpeed,0);
         
        }
    }


    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(itemDelay);
        GetComponent<PlayerScript>().forwardSpeed = 0.2f;
    }
    IEnumerator Rain()
    {
        transform.Translate(0, slowSpeed, 0);
        yield return new WaitForSeconds(weatherDelay);
        transform.Translate(0, forwardSpeed, 0);
    }
    IEnumerator Snow()
    {
        HP = HP--;
        yield return new WaitForSeconds(weatherDelay);

    }
    IEnumerator Wind()
    {
        transform.Translate(0, slowSpeed, 0);
        yield return new WaitForSeconds(weatherDelay);
        transform.Translate(0, forwardSpeed, 0);
    }

}
