using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackPattern : Singleton<Enemy_AttackPattern> 
{
    float delay = 0.2f;
    public void SingleShot(GameObject enemy, GameObject bullet, float angle)
    {
        Vector3 pos = enemy.transform.position;
        Instantiate(bullet, pos, Quaternion.Euler(0, 0, angle));
    }
    public IEnumerator RepeatShot(GameObject enemy, GameObject bullet, float angle, int count)
    {
        Vector3 pos = enemy.transform.position;
        for (int i = 0; i < count; i++)
        {
            Instantiate(bullet, pos, Quaternion.Euler(0, 0, angle));
            yield return new WaitForSeconds(delay);
        }
    }
    public void MultiShot(GameObject enemy, GameObject bullet, int count)//, float angle)
    {
        Vector3 pos = enemy.transform.position;
      
            if(count  % 2 == 0)
            {
                for (int i = 0; i < count/2; i++)
                {
                    Instantiate(bullet, pos, Quaternion.Euler(0, 0, (i+1) * 90 / (2*count)));
                    Instantiate(bullet, pos, Quaternion.Euler(0, 0, (-i-1) * 90 / (2*count)));
                }
            }
        else
        {
            for (int i = 0; i < count/2 +1; i++)
            {
                if (i == 0)
                {
                    Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    Instantiate(bullet, pos, Quaternion.Euler(0, 0, i  * 90 / (2 * count)));
                    Instantiate(bullet, pos, Quaternion.Euler(0, 0, -i * 90 / (2 * count)));
                }
            }
        }
           
        
    }
}
