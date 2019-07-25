using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    public float hp;
    public GameObject hitEffect;
    int reverseTime = 4;
    float startReverseTime;
    public float[] itemWeight;

    private void Start()
    {
        startReverseTime = reverseTime;
    }

    public override void Function(GameObject window)
    {
        
    }

    void DecreaseHP(float damage)
    {
        hp -= damage;
        GameObject temp = Instantiate(hitEffect);
        temp.transform.position = gameObject.transform.position;
        if (hp <= 0)
        {
            Destroy(gameObject);
            ItemManager.Instance.MakeItem(gameObject.transform.position, itemWeight, 1);
        }
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
            if (MobileInputManager.Instance.isReverse == false)
            {
                InputManager.Instance.ReverseSideMove(reverseTime);
            }

            else if (MobileInputManager.Instance.isReverse == true)
            {
                InputManager.Instance.t = 0;               
            }
        }
        else if(collider.gameObject.tag == "Bullet")
        {
            DecreaseHP(player.GetComponent<Ability>().bulletDamage);
        }
    }
   
    IEnumerator Wait()
    {
        while (reverseTime == startReverseTime)
        {
            yield return new WaitForSeconds(1.0f);
            reverseTime ++;
            
        }
   
    }
  
}
