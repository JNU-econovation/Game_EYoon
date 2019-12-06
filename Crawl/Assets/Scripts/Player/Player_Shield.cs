using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    bool isShield;
    static int shieldCount;
    public GameObject shield; //쉴드, 무적, 

    public void Shield()
    {
        shieldCount--;
        if (shieldCount < 0)
            shieldCount = 0;
    }

    public void SetShieldCount(int n)
    {
        shieldCount = n;
    }
    public int GetShieldCount()
    {
        return shieldCount;
    }
    public IEnumerator ShieldEffect()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        shield.SetActive(false);
    }
}
