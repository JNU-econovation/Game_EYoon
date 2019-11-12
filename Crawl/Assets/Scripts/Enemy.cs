using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : Singleton<Enemy>
{
    protected float damage;
<<<<<<< HEAD

=======
    protected float speed = 3.0f;
    protected float originSpeed;
    protected float speed_x = 1.5f;
    protected float originSpeed_x;
>>>>>>> 38241f2dfd96f570d154eca5b2444830088be801
    // Start is called before the first frame update
    void Start()
    {
        originSpeed = speed;
        originSpeed_x = speed_x;
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
<<<<<<< HEAD
            float trueDamage = Player_AbilityManager.Instance.DecreaseHP(damage);
            float reflectDamage = trueDamage * Player_AbilityManager.Instance.GetReflectDamage() / 100;
            GetComponent<Enemy_Ability>().DecreaseHP(reflectDamage);          
=======
            Player_AbilityManager.Instance.DecreaseHP(damage);
            gameObject.GetComponent<Enemy_Ability>().SetHP(0);
>>>>>>> 38241f2dfd96f570d154eca5b2444830088be801
        }
    }
    abstract public void Resume();
    abstract public void Pause();
    abstract public void SetPosition();
}
