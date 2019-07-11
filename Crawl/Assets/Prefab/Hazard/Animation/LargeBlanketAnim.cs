using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeBlanketAnim : Hazard
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

    public override void Function(GameObject window)
    {
        float diffYpos = transform.position.y - player.transform.position.y;
        float diffXpos = transform.position.x - player.transform.position.x;
        if (0 <= diffYpos && diffYpos <= 40 && diffXpos <= 20)
            StartCoroutine(Dark());
    }
    public IEnumerator Dark()
    {
        yield return new WaitForSeconds(3.0f);
        dark.GetComponent<SpriteRenderer>().sprite = black;
    }
}
