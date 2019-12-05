using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Singleton<Bomb>
{
    float speed = 400;
    static public float damage = 10;
    float lifeTime = 5.0f;
    bool isPause;
    void Start()
    {
    }
    void OnEnable()
    {
        StartCoroutine(DestroySelf(lifeTime));
    }
    IEnumerator DestroySelf(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isPause)
            speed = 0;
        else
            speed = 400;
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            SoundManager.Instance.PlayBombSound();
            collider.GetComponent<Enemy>().ShowDamage(damage, new Color(255, 255, 255, 255));
            collider.GetComponent<Enemy_Ability>().DecreaseHP(damage);
            gameObject.SetActive(false);
        }
    }
    public void IncreaseDamage(float n)
    {
        damage += n;
    }
    public float GetDamage()
    {
        return damage;
    }
    public void Pause()
    {
        isPause = true;
    } 
    public void Resume()
    {
        isPause = false;
    }
}
