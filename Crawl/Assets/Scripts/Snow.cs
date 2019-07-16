using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject service;
    int damage = 2;
    int delay = 1;
    // Start is called before the first frame update

    public void SnowEffect()
    {
        StartCoroutine(SnowFunction());
    }

   IEnumerator SnowFunction()
    {
        player = service.GetComponent<LevelManager>().player;
        for (int i =0; i<5; i++)
        {
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
    }
}
