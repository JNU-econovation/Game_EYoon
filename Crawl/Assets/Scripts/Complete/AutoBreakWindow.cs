using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBreakWindow : MonoBehaviour
{
    int maxDistance = 10;

    private void Start()
    {
        StartCoroutine(Punch());
    }

    private IEnumerator Punch()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);           
            BreakWindow();
        }


    }


    void BreakWindow()
    {
        Vector3 targetPosition = transform.position + new Vector3(0, 10, 0);
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, transform.forward, maxDistance);
        if (hit)
        {
            if (hit.collider.gameObject.tag == "Window")
            {
                GameObject target = hit.collider.gameObject;
                target.GetComponent<Window>().DecreaseHP(GetComponent<Ability>().damage);                
                target.GetComponent<Window>().ChangeWindow();
            }

        }
    }
}
