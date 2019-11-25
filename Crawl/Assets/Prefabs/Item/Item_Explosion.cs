using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Explosion : MonoBehaviour
{
    public Vector2 offset = Vector2.zero;
    public float force;
    [SerializeField] float[] itemWeight;
    public GameObject[] items;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explosion()
    {
        yield return null;
        for(int i = 0; i < 20; i++)
        {
            GameObject item = SelectItem();
            Instantiate(item, transform.position,Quaternion.identity);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, transform.position.y) + offset);
        }
    }
    public GameObject SelectItem()
    {
        float rand = Random.Range(0.01f, 100);
        float sum = 0;
        int i = 0;
        while (i < itemWeight.Length)
        {
            sum += itemWeight[i];
            if (rand <= sum)
            {
                return items[i];
            }
            i++;
        }
        return items[0];
    }
    private void OnDisable()
    {
        StartCoroutine(Explosion());
    }
}
