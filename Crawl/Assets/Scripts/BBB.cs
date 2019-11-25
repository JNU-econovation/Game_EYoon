using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBB : Enemy
{
    public override void Pause()
    {
        
    }

    public override void Resume()
    {
       
    }

    public override void SetPosition()
    {
        transform.position = new Vector3(360, 19900, 0);
    }

    void Start()
    {
        SetPosition();
    }


    private void OnDisable()
    {
        LevelManager.Instance.bossClear = true;
        Item_Explosion.Instance.Explosion(transform.position);
    }

}
