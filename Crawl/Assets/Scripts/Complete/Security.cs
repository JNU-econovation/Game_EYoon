using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : Hazard
{
    Ray2D ray;
    RaycastHit2D rayHit;
    float distance = 200;
    [SerializeField] GameObject smallWarning;
    [SerializeField] GameObject bigWarning;
    [SerializeField] int delay; //경고가 뜬 후 경비가 나타나기까지의 시간
    [SerializeField] int existTime; // 경비가 존재하는 시간
    public LayerMask playerLayerMask;

    private void Update()
    {
        ray = new Ray2D(transform.position, Vector2.down);
        rayHit = Physics2D.Raycast(transform.position, Vector2.down, distance, playerLayerMask);
       

        if (rayHit && rayHit.collider.gameObject.tag == "Player")
        {
            print(1);
            rayHit.collider.gameObject.GetComponent<Health>().hp = 0;
        }
    }
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

    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
    }


}
