using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    GameObject player;
    GameObject service;
    ItemManager itemManager;
    public Sprite brokenSprite;
    SpriteRenderer spriteRenderer;
    bool itemMade;
    Sprite originSprite;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        service = GameObject.FindGameObjectWithTag("Service");
        itemManager = service.GetComponent<ItemManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        

        float dist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        if (dist <= 200.0f && !itemMade)
        {
            ChangeSprite(brokenSprite);
            GameObject spawnItem = itemManager.SelectItem();
            Instantiate(spawnItem, transform.position, Quaternion.identity);
            itemMade = true;
        }
    }
    public bool getItemMade()
    {
        return itemMade;
    }
    public void setItemMade(bool temp)
    {
        itemMade = temp;
    }

    public void InitializeSprite() { 
        spriteRenderer.sprite = originSprite;
    }
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
