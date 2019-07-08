using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : Hazard
{
    Ray ray;
    RaycastHit rayHit;
    float distance = 200;
    [SerializeField] GameObject smallWarning;
    [SerializeField] GameObject bigWarning;
    [SerializeField] int delay = 2; //경고가 뜬 후 경비가 나타나기까지의 시간
    [SerializeField] int existTime = 2; // 경비가 존재하는 시간

   
    public override void Function(GameObject window)
    {
        StartCoroutine(Petrol(window));
        
    }
    IEnumerator Petrol(GameObject window)
    {
        
        GameObject warning;
        Vector3 windowPos;
        windowPos = window.transform.position;
        if (window.name == "window2")
        {
            warning = Instantiate(bigWarning);
        }
        else
        {
            warning = Instantiate(smallWarning);
        }
        warning.transform.position = new Vector3(windowPos.x, windowPos.y - 90.2f, windowPos.z);

        yield return new WaitForSeconds(delay);
  

        Destroy(warning);

        gameObject.transform.position = window.transform.position;

        ray = new Ray();
        ray.origin = gameObject.transform.position;
        ray.direction = transform.up * -1;
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            print(343);
        }
        if (Physics.Raycast(ray.origin,ray.direction, out rayHit, distance) && rayHit.collider.gameObject.tag == "Player")
        {
            player.GetComponent<Health>().hp = 0;
        }
        Destroy(gameObject, existTime);

    }


}
