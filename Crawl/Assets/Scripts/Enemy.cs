using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : Singleton<Enemy>
{
    protected float damage;
    protected float speed = 3.0f;
    protected float originSpeed;
    protected float speed_x = 1.5f;
    protected float originSpeed_x;
<<<<<<< HEAD
    void Start()
=======
    protected bool isPaused = false;
    
    void Awake()
>>>>>>> fa136684f4ac2ace9d56350bbd9fbb97d0a8da3d
    {
        originSpeed = speed;
        originSpeed_x = speed_x;
    }
   void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(6.0f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            float trueDamage = Player_AbilityManager.Instance.DecreaseHP(damage);
            float reflectDamage = trueDamage * Player_AbilityManager.Instance.GetReflectDamage() / 100;
            GetComponent<Enemy_Ability>().DecreaseHP(reflectDamage);          
        }
    }
    abstract public void Resume();
    abstract public void Pause();
    abstract public void SetPosition();
}
