using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMaker : Weather
{
    public GameObject warning;
    public GameObject lightning;
    GameObject player;
    int numOfLight;
    int delay = 1;
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
        GameObject temp = Instantiate(lightning);
        temp.transform.position = siren.transform.position;     
        Destroy(siren);
        Destroy(temp, 1);
    }

    public override void OnEnable()
    {
       
    }

    public override void MakeWeather()
    {
        numOfLight = Random.Range(1, 4);
        for(int i = 0; i < numOfLight; i++)
        {
            Instantiate(gameObject);
        }
    }

    public override void Function()
    {
        
    }   
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().DecreaseHP(damege);
        }
    }
}
