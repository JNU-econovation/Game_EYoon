using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Space : MonoBehaviour
{
    public void SetAbility(float color_R, float color_G, float color_B, float hp, float damage)
    {
        GetComponent<SpriteRenderer>().color = new Color(color_R, color_G, color_B);
        GetComponent<Enemy_Ability>().SetHP(hp);
        GetComponent<Enemy_Ability>().SetDamage(damage);
    }
}
