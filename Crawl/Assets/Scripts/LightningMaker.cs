using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMaker : MonoBehaviour
{
    public GameObject warning;
    public GameObject lightning;
    public GameObject lightningWide;
    GameObject player;

    int delay = 1;
    // Start is called before the first frame update
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
        GameObject thunder = Instantiate(lightning);
        GameObject wide = Instantiate(lightningWide);
        thunder.transform.position = siren.transform.position;
        wide.transform.position = siren.transform.position;
        Destroy(siren);
        Destroy(thunder, 1);
        Destroy(wide, 1);
    }
}
