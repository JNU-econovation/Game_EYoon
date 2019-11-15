using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : Singleton<Window>
{
    GameObject player;
    GameObject service;
    ItemManager itemManager;
    public Sprite brokenSprite;
    SpriteRenderer spriteRenderer;
    bool itemMade;
    Sprite originSprite;
    static float maxX = 50;
    static float maxY = 250;
    bool isMagnet;
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

        float distX = Mathf.Abs(player.transform.position.x - transform.position.x);
        float distY = transform.position.y - player.transform.position.y;
        float dist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
       
        if (distX <= maxX && 0<=distY && distY <= maxY && !itemMade)
        {
            ChangeSprite(brokenSprite);
            GameObject spawnItem = itemManager.SelectItem();
            Instantiate(spawnItem, transform.position, Quaternion.identity);
            itemMade = true;
        }
    }
    public void Magnet()
    {
        maxX = 200;
        maxY = 500;
    }
    public void UnMagnet()
    {
        maxX = 50;
        maxY = 250;
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
