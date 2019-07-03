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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maxArmor = player.GetComponent<Ability>().maxArmor;
        armor = player.GetComponent<Ability>().armor;       
        decrease = decrease * (1 - (armor / maxArmor));
        fireHp = fire.GetComponent<Fire>().HP;        
        bulletDamage = bullet.GetComponent<Bullet>().damage;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.gameObject.tag == "Player")
        {                     
                Function();                               
        }
        else if(collider.gameObject.tag == "bullet")
        {

            fireHp -= bulletDamage;
            if (fireHp <= 0)
            {
                Destroy(gameObject);               
            }
            Destroy(collider.gameObject);

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
