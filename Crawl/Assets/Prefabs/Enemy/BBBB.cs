using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBB : Enemy
{
    public override void Pause()
    {

    }

    public override void Resume()
    {

    }

    public override void SetPosition()
    {
        transform.position = new Vector3(360, 39900, 0);
    }

    void Start()
    {
        SetPosition();
    }


    private void OnDisable()
    {
        LevelManager.Instance.bossClear = true;
    }
}
