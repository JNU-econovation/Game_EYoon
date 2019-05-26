using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmaker : MonoBehaviour
{
  
    [SerializeField] GameObject npc;//주민 등록
    [SerializeField] int delay = 2; //주민 소환 함수를 돌리는 주기
     [SerializeField]int dist = 80;//플래이어로부터 어느정도 위에서부터 주민이 물건을 던지는지 정의하는 변수
    [SerializeField] int rate = 40; // 주민 스폰 확률


    void Start()
    {
        StartCoroutine(npcSpawn());
    }

    IEnumerator npcSpawn()
    {
        while (true) {
            Transform player = GameObject.FindWithTag("Player").transform;
             int random = Random.Range(0,rate);
                if (random == 1 && transform.position.y - player.position.y < 165 && transform.position.y -dist > player.position.y )
                {
                    Instantiate(npc, transform.position, transform.rotation);
                    yield return new WaitForSeconds(delay);
                }
                else if(random > 1)
                    {
                yield return new WaitForSeconds(delay);
            }
            
        }
    }
}
