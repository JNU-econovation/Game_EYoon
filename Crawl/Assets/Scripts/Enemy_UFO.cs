using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UFO : Enemy
{
    public int birdPos;
    int direction;
    [SerializeField] float damage;
    [SerializeField] int speed;
    [SerializeField] GameObject bullet;
    [SerializeField] float attackRange;
    [SerializeField] float attackDelay;
    int originSpeed;
    bool attack = false;
    GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        SetPosition();
        originSpeed = speed;
        player = LevelManager.Instance.getPlayer();
    }
    private void Update()
    {
        float distance_y = transform.position.y - player.transform.position.y;

        transform.Translate(5 * direction, 0, 0);
        if(attack == false && distance_y < attackRange)
        {
            StartCoroutine(Attack(distance_y));
        }
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
        Destroy(gameObject);
    }

    IEnumerator Attack(float distance_y)
    {
        attack = true;
        float distance_x = player.transform.position.x - transform.position.x;
        float angle = Mathf.Atan2(distance_y, distance_x);
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(attackDelay);
        attack = false;
    }


    public override void SetPosition()
    {
        int dir = Random.Range(0, 100);
        int birdPos = 700 + Random.Range(0, 200);
        //float playerHeight = LevelManager.Instance.getPlayer().transform.position.y;
        float playerHeight = 400;
        if (dir <= 50)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(796, birdPos + playerHeight);
            direction = -1;
        }
        else if (50 < dir && dir <= 100)
        {
            transform.position = new Vector2(-76, birdPos + playerHeight);
            direction = 1;
        }
    }

}
