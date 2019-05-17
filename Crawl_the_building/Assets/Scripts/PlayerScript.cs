using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float sideMove;
    [SerializeField] float forwardSpeed;
    [SerializeField] float moveDistance;
    //[SerializeField] int NofBullet = 30; // 초기 총알 개수 
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
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "buildingMover")
        {
            other.transform.parent.Translate(0, moveDistance, 0);
        }
        
    }


    
    
  
}
