using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public float damage;
    float delay = 1.0f;
    public GameObject playerFireEffect;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            PlayerEffect.Instance.fireEffect.SetActive(true);          
            StartCoroutine(Damage(collider.gameObject));
        }
    }

    IEnumerator Damage(GameObject player)
    {
        for (int i = 0; i < 5; i++)
        {
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
    }

}
