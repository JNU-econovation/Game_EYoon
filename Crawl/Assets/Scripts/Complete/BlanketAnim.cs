using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketAnim : MonoBehaviour
{

    public float lifeTime = 5.0f;
    public GameObject dark;
    public GameObject black;
    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

  public  void ActiveFunction()
    {
        dark.SetActive(false);
        black.SetActive(true);
    }
    public void InactiveFunction()
    {
        black.SetActive(false);
        dark.SetActive(true);
    }
    public IEnumerator Dark()
    {
        yield return new WaitForSeconds(3.0f);
  
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            ActiveFunction();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        InactiveFunction(); 
    }
}
