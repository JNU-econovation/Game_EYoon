using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shield : MonoBehaviour
{
    bool isShield;
    static int shieldCount;

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
}
