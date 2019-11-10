using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Target : MonoBehaviour
{
    float attack_range; // 실제 반지름 = range * 70
    public Collider2D[] enemy_colliders;
    public LayerMask layerMask;
    void Start()
    {
      
    }
 
    private void Update()
    {
        attack_range = Player_AbilityManager.Instance.GetAttackRange();
        enemy_colliders = Physics2D.OverlapCircleAll(transform.position, attack_range * 70.0f, layerMask);
    }

    public Collider2D[] GetEnemyColliders()
    {
        return enemy_colliders;
    }
}
