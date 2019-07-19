using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public void ChooseAttack()
    {
        bool isAttacking = AutoAttack.Instance.isAttacking;
        if(isAttacking == true)
        {
            AutoAttack.Instance.isAttacking = false;
        }
        else
        {
            AutoAttack.Instance.isAttacking = true;
            AutoAttack.Instance.StartAttack();
        }
    }
}
