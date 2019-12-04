using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : Singleton<Enemy_AttackPattern> 
{
    float delay = 0.2f;
    List<GameObject> bullets = new List<GameObject> ();
    public void SingleShot(GameObject enemy, GameObject bullet, float angle, float damage)
    {
        Vector3 pos = enemy.transform.position;
        GameObject bullet0 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, -angle));
        bullet0.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
        bullets.Add(bullet0);
    }
    public IEnumerator RepeatShot(GameObject enemy, GameObject bullet, float angle, int count, float damage)
    {
        Vector3 pos = enemy.transform.position;
        for (int i = 0; i < count; i++)
        {
            GameObject bullet0 =Instantiate(bullet, pos, Quaternion.Euler(0, 0, angle));
            bullet0.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
            bullets.Add(bullet0);
            yield return new WaitForSeconds(delay);
        }
    }
    public void CircleShot(GameObject enemy, GameObject bullet, int count, float damage)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bullet0 = Instantiate(bullet, enemy.transform.position, Quaternion.Euler(0, 0, 360 / count * (i)));
            bullet0.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
            bullets.Add(bullet0);
        }
    }
    public void QuarterCircleShot(GameObject enemy, GameObject bullet, int count, float damage)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bullet0 = Instantiate(bullet, enemy.transform.position, Quaternion.Euler(0, 0, 45 + 360 / count * (i)));
            bullet0.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
            bullets.Add(bullet0);

        }
    }
    public void MultiShot(GameObject enemy, GameObject bullet, int count, float damage)//, float angle)
    {
        Vector3 pos = enemy.transform.position;
      
            if(count  % 2 == 0)
            {
                for (int i = 0; i < count/2; i++)
                {
                   GameObject bullet1 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, (i+1) * 90 / (2*count)));
                   GameObject bullet2 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, (-i-1) * 90 / (2*count)));
                bullet1.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
                bullet2.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
                bullets.Add(bullet1);
                bullets.Add(bullet2);

            }
            }
        else
        {
            for (int i = 0; i < count/2 +1; i++)
            {
                if (i == 0)
                {
                    GameObject bullet0 =Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
                    bullet0.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
                    bullets.Add(bullet0);
                }
                else
                {
                    GameObject bullet1 = Instantiate(bullet, pos, Quaternion.Euler(0, 0, i  * 90 / (2 * count)));
                    GameObject bullet2 =Instantiate(bullet, pos, Quaternion.Euler(0, 0, -i * 90 / (2 * count)));
                    bullet1.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
                    bullet2.GetComponent<Enemy_BulletDamage>().Setdamage(damage);
                    bullets.Add(bullet1);
                    bullets.Add(bullet2);
                }
            }
        }
           
            
        
    }
   public void Pause()
    {
        for(int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                    bullets[i].GetComponent<Enemy_UFO_bullet>().Stop();
            }
            
        }
    }
    public void Resume()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                if (bullets[i].GetComponent<Enemy_SatelliteMonster>() == null)
                    bullets[i].GetComponent<Enemy_UFO_bullet>().Resume();
                else
                    bullets[i].GetComponent<Enemy_SatelliteMonster>().Resume();
            }

        }
    }
}
