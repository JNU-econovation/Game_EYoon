using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    Player_Move player_Move;
    public Animator animator;
    public Animator anim_Sea;
    void Start()
    {
        player_Move = GetComponent<Player_Move>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = player_Move.PoolInput();
        float h = vector.x;
        float v = vector.y;
        if(h != 0 || v != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void SetAnimator(Animator anim)
    {
        animator = anim;
    }
}
