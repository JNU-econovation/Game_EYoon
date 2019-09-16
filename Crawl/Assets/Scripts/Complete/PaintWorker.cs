using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintWorker : Hazard
{
    public Image hpImage;
    public float speed;
    public float damage;
    public float hp;
    public float maxHp;
    public float[] itemWeight;
    public GameObject hitEffect;
    private void Update()
    {
        transform.Translate(0, -speed, 0);
    }

    public override void Function(GameObject window)
    {
        transform.position = new Vector3(Random.Range(300,420), player.transform.position.y + 100, 0);
    }
  
    void DecreaseHP(float n)
    {
        hp -= n;
        GameObject temp = Instantiate(hitEffect);
        temp.transform.position = gameObject.transform.position;
        if (hp <= 0)
        {
            Destroy(gameObject);            
            ItemManager.Instance.MakeItem(gameObject.transform.position, itemWeight, 1);           
            
        }           
        hpImage.fillAmount = hp / maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            collider.gameObject.GetComponent<Health>().DecreaseHP(damage);
            collider.GetComponent<AudioSource>().enabled = false;
            collider.GetComponent<AudioSource>().enabled = true;
        }
    }
}
