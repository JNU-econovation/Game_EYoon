using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] GameObject[] paint;
    int delay = 1;
    int paintExistTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PaintWall());
    }

    // Update is called once per frame
   IEnumerator PaintWall()
    {
        while (true)
        {
            int rand = Random.Range(0, 2);
            Instantiate(paint[rand],gameObject.transform.position,gameObject.transform.rotation);
            yield return new WaitForSeconds(delay);
            
        }
    }
}
