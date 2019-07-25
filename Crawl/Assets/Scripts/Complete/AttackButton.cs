using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackButton : Singleton<AttackButton>
{
    public bool isClicked = false;
    [SerializeField] GameObject shoot;
   
            
      

    public void Attack(GameObject shoot)
    {
        if(isClicked == false)
        {
            isClicked = true;
            AutoAttack.Instance.StartAttack(isClicked);
        }
        else
        {
            isClicked = false;        
            AutoAttack.Instance.StopAttack(isClicked);
        }
    }
}
