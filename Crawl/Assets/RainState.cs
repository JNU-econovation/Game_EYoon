using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainState : Singleton<RainState>
{
    public bool isRain;
    private void OnEnable()
    {
        isRain = true;
    }
    private void OnDisable()
    {
        isRain = false;
    }
}
