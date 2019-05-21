using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text NOBullet; //총알 개수
    public Text HPValue;
    public GameObject player;
    Attack playerAttack;
    public int temp;
    private void Start()
    {

        playerAttack = player.GetComponent<Attack>();
    }
    void Update()
    {

        temp = playerAttack.NumberOfBullet;
        NOBullet.text = temp.ToString();
    }

}
