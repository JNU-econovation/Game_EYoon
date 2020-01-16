using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
abstract public class Enemy : Singleton<Enemy>
{
    protected float damage;
    public float speed;
    protected float originSpeed;
    public float speed_x = 1.5f;
    protected float originSpeed_x;
    public bool isPaused;
    Enemy_Ability enemy_Ability;
    public bool OnAttack;
    public float lifeTime;
    protected float time = 0;
    public float savedSpeed;
    public float savedSpeed_x;
    public GameObject enemy_Damage;
    public bool stop;
    void Awake()
    {       
        enemy_Ability = GetComponent<Enemy_Ability>();
        originSpeed = speed;
        originSpeed_x = speed_x;
        damage = GetComponent<Enemy_Ability>().GetDamage();

    }
    void OnEnable()
    {
        if (!LevelManager.Instance.OnBoss)
            StartCoroutine(DestroySelf());
    }
  
    IEnumerator DestroySelf()
    {
        while (true)
        {
            yield return null;
            if(time >= lifeTime)
            {
                if (LevelManager.Instance.level == 0)
                    EffectManager.Instance.SpawnWaterDeath(transform);
                else if (LevelManager.Instance.level == 1)
                    EffectManager.Instance.SpawnSkyDeath(transform);
                else if (LevelManager.Instance.level >= 2)
                    EffectManager.Instance.SpawnSpaceDeath(transform);
                Destroy(gameObject);
            }
        }
        
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
    public void ShowDamage(float damage, Color color, int a)
    {
        GameObject hudText = Instantiate(enemy_Damage);
        hudText.GetComponent<TextMeshPro>().color = color;
        if(a == 1)
            hudText.transform.position = transform.position + new Vector3(0, 100, 0);
        else
            hudText.transform.position = transform.position + new Vector3(100, 100, 0);
        hudText.GetComponent<Enemy_DamageText>().damage = damage;
    }
    public bool GetOnAttack()
    {
        return OnAttack;
    }   
    abstract public void SetPosition();
}
