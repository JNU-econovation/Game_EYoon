using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_AbilityText : MonoBehaviour
{
    [SerializeField] Text attack;
    [SerializeField] Text defense;
    [SerializeField] Text criticalPercent;
    [SerializeField] Text criticalHit;
    [SerializeField] Text attackSpeed;
    [SerializeField] Text moveSpeed;
    [SerializeField] Text attackrange;
    [SerializeField] Text avoidance;  

    
    void Update()
    {
        attack.text = Player_AbilityManager.Instance.GetAttack().ToString();
        defense.text = Player_AbilityManager.Instance.GetDefense().ToString();
        criticalPercent.text = Player_AbilityManager.Instance.GetCritical_Percentage().ToString();
        criticalHit.text = Player_AbilityManager.Instance.GetCritical_HIt().ToString();
        attackSpeed.text = Player_AbilityManager.Instance.GetAttackRange().ToString();
        moveSpeed.text = Player_AbilityManager.Instance.GetMoveSpeed().ToString();
        attackrange.text = Player_AbilityManager.Instance.GetAttackRange().ToString();
        avoidance.text = Player_AbilityManager.Instance.GetAvoidance().ToString();     
    }
}
