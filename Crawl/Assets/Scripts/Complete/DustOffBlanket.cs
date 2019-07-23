using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    static float reverseTime = 4.0f;
    float startReverseTime;
    bool isReverse = false;
    private void Start()
    {
        startReverseTime = reverseTime;
    }
    public override void Function(GameObject window)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" )
        {
            collider.gameObject.GetComponent<Ability>().isReverse = true;          
            InputManager.Instance.isReverse = true;
            InputManager.Instance.ChangeSideMove();
            MobileInputManager.Instance.isReverse = true;
            StartCoroutine(Wait());
        }
    }
   IEnumerator RecoverReverse(GameObject player)
    {
        yield return new WaitForSeconds(reverseTime);
        if (player.GetComponent<Ability>().isReverse == true)
        {
            InputManager.Instance.isReverse = true;

        }
        else
        {
            InputManager.Instance.isReverse = false;
            player.GetComponent<Ability>().isReverse = false;
            InputManager.Instance.ChangeSideMove();
        }

    }
    IEnumerator Wait()
    {
        player.GetComponent<Ability>().isReverse = false;
        while (reverseTime >= 0)
        {
            yield return new WaitForSeconds(0.2f);
            reverseTime -= 0.2f;
            if(player.GetComponent<Ability>().isReverse == true)
            {
                reverseTime = startReverseTime;
            }
        }       
        InputManager.Instance.isReverse = false;
        InputManager.Instance.ChangeSideMove();
    }


}
