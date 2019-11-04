using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    [SerializeField] int shotcount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
    }


    IEnumerator attack()
    {
        while (true)
        {
            Enemy_AttackPattern.Instance.MultiShot(gameObject, bullet, shotcount);
            yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
