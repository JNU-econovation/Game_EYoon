using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : Hazard
{
    public GameObject security;
    GameObject targetWindow;
    public override void Function(GameObject window)
    {
        targetWindow = window;
        HazardManager.Instance.WindowOpen(window);
        StartCoroutine(SpawnSecurity());
    }
    IEnumerator SpawnSecurity()
    {
        yield return new WaitForSeconds(lifeTime);
        GameObject temp = Instantiate(security);
        temp.transform.position = targetWindow.transform.position;
        temp.GetComponent<Security>().Function(targetWindow);
    } 

}
