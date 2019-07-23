using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    static float reverseTime = 4.0f;
    float startReverseTime;
    private void Start()
    {
        startReverseTime = reverseTime;
    }
    public override void Function(GameObject window)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            reverseTime = startReverseTime;
            InputManager.Instance.isReverse = true;
            InputManager.Instance.ChangeSideMove();
            MobileInputManager.Instance.isReverse = true;
            StartCoroutine(RecoverReverseMove());
        }
    }
   
    IEnumerator RecoverReverseMove()
    {
        while (reverseTime > 0.0f)
        {
            yield return new WaitForSeconds(1.0f);
            reverseTime--;
            
        }
        if (reverseTime < 0)
            reverseTime = startReverseTime;
        InputManager.Instance.isReverse = false;
        InputManager.Instance.ChangeSideMove();
    }
  
}
