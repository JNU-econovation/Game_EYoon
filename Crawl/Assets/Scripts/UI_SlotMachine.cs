using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SlotMachine : MonoBehaviour
{
    float moveSpeed = 10000;
    float time;
    bool waitTwoSecond;
    public int slotNum;
    public GameObject scroll;
    public GameObject button;
    int button_skillNum;  
   

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 2.0f)
        {
            waitTwoSecond = true;
        }
        transform.Translate(0, -Time.deltaTime * moveSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject == scroll)
        {
            transform.Translate(0, 1760, 0);
        }        
        
    }
    public int GetSlotNum()
    {
        return slotNum;
    }
    public void SetSlotNum(int n)
    {
        slotNum = n;
    }
    public bool Getwait()
    {
        return waitTwoSecond;
    }
    public void Stop()
    {
        moveSpeed = 0;
    }
}
