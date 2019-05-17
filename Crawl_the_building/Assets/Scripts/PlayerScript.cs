using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float sideMove;
    [SerializeField] float forwardSpeed;
    [SerializeField] float itemDelay;
    [SerializeField] float moveDistance;
    [SerializeField] float weatherDelay;
    [SerializeField] float slowSpeed;
    [SerializeField] int HP;
    [SerializeField] int heatDamage;
    [SerializeField] int NofBullet = 30; // 초기 총알 개수 
    void Update()
    {
        transform.Translate(0, forwardSpeed, 0);


        if (Input.GetKey(KeyCode.D) )
        {
            transform.Translate(sideMove*Time.deltaTime, 0, 0);
            Debug.Log(1);
          
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-sideMove*Time.deltaTime, 0, 0);
            Debug.Log(1);
        }
     
      

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "buildingMover")
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
