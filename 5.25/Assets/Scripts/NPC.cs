using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject[] stuffs;// 주민이 던질 물건들
    Transform player;//플래이어의 위치
    [SerializeField] int existTime;//주민이 존재하는 시간

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(attack());
    }
 

    IEnumerator attack()
    {
        float dx = player.position.x - transform.position.x;
        float dy = player.position.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        Instantiate(stuffs[Random.Range(0,stuffs.Length)], transform.position, Rotation);
        yield return new WaitForSeconds(existTime);
        Destroy(gameObject);
    }
}
