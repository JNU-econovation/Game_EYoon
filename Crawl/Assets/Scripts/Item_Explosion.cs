using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Explosion : Singleton<Item_Explosion>
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

    public void Explosion(Vector3 bossPos)
    {
        for(int i = 0; i < 15; i++)
        {
            GameObject temp = Instantiate(SelectItem(), bossPos, Quaternion.identity);
            float randX = Random.Range(-3, 3);
            temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(randX, 5) * force, ForceMode2D.Impulse);
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
}
