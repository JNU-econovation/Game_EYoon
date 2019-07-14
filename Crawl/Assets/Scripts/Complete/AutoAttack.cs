using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    Vector3 spawnPosition;
    public GameObject bullet;
    GameObject target;
    int maxDistance = 10;
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            MakeBullet();
        }


    }

    void MakeBullet()
    {
        spawnPosition = transform.position + new Vector3(0, 10, 0);
        // spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
        RaycastHit2D hit = Physics2D.Raycast(spawnPosition, transform.forward, maxDistance);
        if (hit)
        {
            target = hit.transform.gameObject;
            print(target);
            bullet.GetComponent<Bullet>().target = target;
            float dx = spawnPosition.x - transform.position.x;
            float dy = spawnPosition.y - transform.position.y;
            float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            Instantiate(bullet, transform.position, rotation);                     
        }
    }


}
