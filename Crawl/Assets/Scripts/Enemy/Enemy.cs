using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : Singleton<Enemy>
{
    protected float damage;
    public float speed;
    protected float originSpeed;
    public float speed_x = 1.5f;
    protected float originSpeed_x;
    protected bool isPaused = false;
    Enemy_Ability enemy_Ability;
    public bool OnAttack;
    public float lifeTime;
    void Awake()
    {
        
        enemy_Ability = GetComponent<Enemy_Ability>();
        originSpeed = speed;
        originSpeed_x = speed_x;
        damage = GetComponent<Enemy_Ability>().GetDamage();
    }
    void OnEnable()
    {
        if(!LevelManager.Instance.OnBoss)
            StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
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
    public bool GetOnAttack()
    {
        return OnAttack;
    }
    abstract public void SetAbillity(float color_R,float color_G, float color_B, float hp, float damage, float bulletCount);
    abstract public void Resume();
    abstract public void Pause();
    abstract public void SetPosition();
}
