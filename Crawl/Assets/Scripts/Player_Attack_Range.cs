using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Range : MonoBehaviour
{
    [SerializeField] float attackRange;
    Player_Circle_Move circle;
    void Start()
    {
        circle = GetComponentInChildren<Player_Circle_Move>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.localScale = new Vector3(attackRange, attackRange,1);
        circle.setRadius(attackRange * 70);
        circle.transform.localScale = new Vector3(0.1f, 0.1f, 0);
    }
}
