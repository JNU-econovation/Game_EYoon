using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : Singleton<AutoAttack>
{
    public GameObject bullet;
    GameObject target;
    int maxDistance = 10;
    public bool isAttack = false;
    public GameObject shootSound;
    AudioSource audioSource;
    int rand;
    private void Start()
    {
        audioSource = shootSound.GetComponent<AudioSource>();
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            if (isAttack == true)
            {
                rand = Random.Range(0, 2);
                if(rand == 0)
                {
                    audioSource.enabled = true;
                    audioSource.Play();
                    MakeBullet();
                }

            }

            else
            {
                shootSound.GetComponent<AudioSource>().enabled = false;
                break;
            }
            yield return new WaitForSeconds(0.06f);
        }

    }

    public void StartAttack(bool isClicked)
    {
        isAttack = isClicked;
        StartCoroutine(Shoot());
    }
    public void StopAttack(bool isClicked)
    {
        isAttack = isClicked;
    }

    void MakeBullet()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 10, 0);       
        // spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
        RaycastHit2D hit = Physics2D.Raycast(spawnPosition, transform.forward, maxDistance);
        if (hit)
        {
            target = hit.transform.gameObject;            
          //  bullet.GetComponent<Bullet>().target = target;
            float dx = spawnPosition.x - transform.position.x;
            float dy = spawnPosition.y - transform.position.y;
            float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            Instantiate(bullet, transform.position, rotation);                     
        }
    }

   


}
