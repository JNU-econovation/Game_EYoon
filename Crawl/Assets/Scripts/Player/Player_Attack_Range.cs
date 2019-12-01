using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Range : MonoBehaviour
{
    [SerializeField] float attackRange;
    float maxAttackRange = 15;
    Player_Circle_Move circle;
    void Start()
    {
        circle = GetComponentInChildren<Player_Circle_Move>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.localScale = new Vector3(attackRange, attackRange,1);
        circle.setRadius(attackRange * 45);
    }
    public float GetAttackRange()
    {
        return attackRange;
    }
    public void IncreaseAttackRange(float n)
    {
        attackRange += n;
        if (attackRange > maxAttackRange)
            attackRange = maxAttackRange;
    }
}
