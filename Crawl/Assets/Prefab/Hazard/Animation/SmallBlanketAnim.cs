using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBlanketAnim : Hazard
{
    public GameObject dark;
    public Sprite black;
    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
   
    public IEnumerator Dark()
    {
        yield return new WaitForSeconds(3.0f);
        dark.GetComponent<SpriteRenderer>().sprite = black;
    }

    public override void Function(GameObject window)
    {
        print(1111111);
        float diffPos = transform.position.y - player.transform.position.y;
        if(0<= diffPos && diffPos <= 40)
             StartCoroutine(Dark());
    }
}
