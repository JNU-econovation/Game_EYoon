using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningMaker : Weather
{
    public GameObject warning;  
    public GameObject lightning;
    [SerializeField] GameObject flash;
    int numOfLight;
    int delay = 1;
    public float damege;
    


    public override void MakeWeather()
    {
        numOfLight = Random.Range(1, 4);
        for(int i = 0; i < numOfLight; i++)
        {
            warning.SetActive(true);
            lightning.transform.position = warning.transform.position;
            lightning.SetActive(true);
            
        }
     //   StartCoroutine(LighningFlash());

    }

    IEnumerator LighningFlash()
    {
        yield return new WaitForSeconds(lightning.GetComponent<Lighning>().delay);
        float flashDelay = 0.4f;
        flash.GetComponent<Animator>().SetBool("Flash", true);
        yield return new WaitForSeconds(flashDelay);
        flash.GetComponent<Animator>().SetBool("Flash", false);
    }
    public override void Function()
    {
        
    }   
   

}
