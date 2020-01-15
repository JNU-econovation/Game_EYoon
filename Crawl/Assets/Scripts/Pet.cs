using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : Singleton<Pet>
{
    Player _player;
    float attack;
    float critical_hit;
    float critical_Percent;
    float attackSpeed = 3;
    public GameObject[] bullet;
    public float[] bulletWeight;
    bool onPet;
    float time;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        _player = GetComponentInParent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Attack());
    }
    
    IEnumerator Attack()
    {
        while (true)
        {
            if (onPet)
            {               
                if(time >= attackSpeed)
                {
                    Instantiate(SelectBullet(), transform.position, Quaternion.identity);
                    time = 0;
                }
            }
            yield return null;
        }
    }
    
    GameObject SelectBullet()
    {
        float rand = Random.Range(0.01f, 100);
        float sum = 0;
        int i = 0;
        while (i < bulletWeight.Length)
        {
            sum += bulletWeight[i];
            if (rand <= sum)
            {
                return bullet[i];
            }
            i++;
        }
        return bullet[0];
    }
    private void Update()
    {
        if (!_player.GetIsPause())
        {
            time += Time.deltaTime;
        }
    }
    public void SetOnPet(bool temp)
    {
        onPet = temp;
        spriteRenderer.color = new Color(255,255,255,255);
    }
}
