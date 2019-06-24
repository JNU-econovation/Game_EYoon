using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text NOBullet; //총알 개수
    public GameObject player;
    public int temp;

   
    void Update()
    {
        temp = player.GetComponent<Attack>().NumberOfBullet;
        NOBullet.text = temp.ToString();
    }

}
