using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : Enemy
{
    float birdPos;
    int direction;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] Animator[] species;
    float originSpeed;
    GameObject player;
    Quaternion quaternion = Quaternion.Euler(0, 180f, 0);
    private void Start()
    {
        originSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        SelectSpecies();
        SetPosition();
    }
    private void Update()
    {
        transform.Translate(5 * direction,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Function();
        }
    }
    public override void Function()
    {
        Player_AbilityManager.Instance.DecreaseHP(damage);
       // Destroy(gameObject);
    }

    public override void Pause()
    {
        speed = 0;
    }
    public override void Resume()
    {
        speed = originSpeed;
    }


    public override void SetPosition()
    {
        int dir = Random.Range(0, 100);
        
        float playerHeight = player.transform.position.y;
        birdPos = playerHeight +300+ Random.Range(0, 200);

        if (dir <= 50)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(796, birdPos + playerHeight);
            direction = -1;
        }
        else if ( 50 < dir && dir <= 100)
        {
            transform.position = new Vector2(-76, birdPos + playerHeight);
            direction = 1;
        }
    }
    void SelectSpecies()
    {
        int rand = Random.Range(1, 4);
        print(rand);
        GetComponent<Animator>().SetInteger("Species", rand);
    }
}
