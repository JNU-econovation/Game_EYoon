using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBBB : Enemy
{
    public override void Pause()
    {

    }
    public override void SetAbillity(float color_R, float color_G, float color_B, float hp, float damage, float bulletCount)
    {
        throw new System.NotImplementedException();
    }
    public override void Resume()
    {

    }

    public override void SetPosition()
    {
        transform.position = new Vector3(360, 59900, 0);
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
