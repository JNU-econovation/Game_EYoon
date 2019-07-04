using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    public GameObject fire;
    public GameObject bullet;
    float hp;
    public float decrease;
    float armor;
    float maxArmor;
    GameObject player;
    float fireHp;
    float fireMaxHp;
    float bulletDamage;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maxArmor = player.GetComponent<Ability>().maxArmor;
        armor = player.GetComponent<Ability>().armor;       
        decrease = decrease * (1 - (armor / maxArmor));
        fireHp = fire.GetComponent<Fire>().HP;                
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.gameObject.tag == "Player")
        {                     
                Function();                               
        }
        
    }

    void Function()
    {     
         for (int i = 0; i < 5; i++)
         {
            player.GetComponent<Health>().hp -= decrease;
            StartCoroutine(DelayOneSecond());
         }
    }
    IEnumerator DelayOneSecond()
    {       
        yield return new WaitForSeconds(1.0f);
    }
   
}
