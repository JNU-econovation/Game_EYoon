using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isPause;
    
    public bool GetIsPause()
    {
        return isPause;
    }
    public void SetIsPause(bool temp)
    {
        isPause = temp;
    }
    public void Pause()
    {
        isPause = true;
    }
    public void Resume()
    {
        isPause = false;
    }

    public void InitializeValue()
    {
        GetComponent<Player_Shield>().SetShieldCount(0);

    }
}
