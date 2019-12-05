using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main_Dolphin : MonoBehaviour
{
    public float moveSpeed;
    public float rotateAngle;
    Color color;
    void Awake()
    {
        color = GetComponent<SpriteRenderer>().color;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.z < 0)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(-moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime, 0);
        }
        transform.Rotate(0, 0, rotateAngle * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Block")
        {
            Color color = GetComponent<SpriteRenderer>().color;
            if (color.a > 0.0f)
            {
                Destroy(gameObject);
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
        
    }
}
