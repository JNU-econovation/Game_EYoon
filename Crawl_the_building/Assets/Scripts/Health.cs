using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HP;
    public Vector3 offset; //캐릭터와 체력바의 간격
    public Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        HP.transform.position = player.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
