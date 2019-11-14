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
    // Start is called before the first frame update
    void Start()
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
            Player_AbilityManager.Instance.DecreaseHP(damage);
            gameObject.GetComponent<Enemy_Ability>().SetHP(0);
        }
    }
    abstract public void Resume();
    abstract public void Pause();
    abstract public void SetPosition();
}
