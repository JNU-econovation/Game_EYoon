using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    public float hp;
    public GameObject hitEffect;
    static float reverseTime = 4.0f;
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
            reverseTime = startReverseTime;
            InputManager.Instance.isReverse = true;
            InputManager.Instance.ChangeSideMove();
            MobileInputManager.Instance.isReverse = true;
            StartCoroutine(RecoverReverseMove());
        }
        else if(collider.gameObject.tag == "Bullet")
        {
            hp -= player.GetComponent<Ability>().bulletDamage;
        }
    }
   
    IEnumerator RecoverReverseMove()
    {
        while (reverseTime > 0.0f)
        {
            yield return new WaitForSeconds(1.0f);
            reverseTime--;
            
        }
        if (reverseTime < 0)
            reverseTime = startReverseTime;
        InputManager.Instance.isReverse = false;
        InputManager.Instance.ChangeSideMove();
    }
  
}
