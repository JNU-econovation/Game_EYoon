using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighning : MonoBehaviour
{
   [SerializeField] GameObject player;
    public int delay = 1;
   [SerializeField] GameObject warning;
   [SerializeField]
    public float damege;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(LightningMake());
    }

    IEnumerator LightningMake()
    {
        GameObject siren = Instantiate(warning);
        siren.transform.position = new Vector2(Random.Range(335, 385), player.transform.position.y + Random.Range(10, 80));
        yield return new WaitForSeconds(delay);
        GameObject temp = Instantiate(gameObject);
        temp.transform.position = siren.transform.position;
        Destroy(siren);
        Destroy(temp, 1);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().DecreaseHP(damege);
        }
    }
}
