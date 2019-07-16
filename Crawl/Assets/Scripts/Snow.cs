using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject service;
    static float damage = 2;
    float delay = 1.0f;
    // Start is called before the first frame update

    private void Start()
    {
    }
    public void SnowEffect()
    {
        StartCoroutine(Damage());
    }

   IEnumerator Damage()
    {       
        player = service.GetComponent<LevelManager>().player;
        for (int i =0; i<5; i++)
        {
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
    }

    public void DecreaseDamage(float level)
    {
        damage = 2.0f - (0.2f * level);
    }
   

}
