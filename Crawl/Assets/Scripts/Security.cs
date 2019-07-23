using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : Hazard
{
    Ray2D ray;
    RaycastHit2D rayHit;
    float distance = 200;
    [SerializeField] GameObject siren;
    [SerializeField] int delay; //경고가 뜬 후 경비가 나타나기까지의 시간
    public LayerMask playerLayerMask;
    
    private void Update()
    {
        ray = new Ray2D(transform.position, Vector2.down);
        rayHit = Physics2D.Raycast(transform.position, Vector2.down, distance, playerLayerMask);
       

        if (rayHit && rayHit.collider.gameObject.tag == "Player")
        {
            if (rayHit.collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            Manager.Instance.Gameover();
        }
    }
    public override void Function(GameObject window)
    {
        
        StartCoroutine(Petrol(window));
        HazardManager.Instance.WindowOpen(window);
        
    }
    
    IEnumerator Petrol(GameObject window)
    {       
        GameObject warning = Instantiate(siren);
        warning.transform.position = window.transform.position;

        yield return new WaitForSeconds(delay);  
        Destroy(warning);
        gameObject.transform.position = window.transform.position;

    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
    }


}
