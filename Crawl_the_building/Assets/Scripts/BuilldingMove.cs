using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilldingMove : MonoBehaviour
{
    float moveDistance;
    public GameObject[] maps; //소환하려는 맵들
    int count; //buildingMover와 충돌한 횟수
    int firstPhase; // 창문의 체력이 바뀌는 첫번째 지점 정의
    int secondPhase; //창문의 체력이 바뀌는 두번째 지점 정의
    int thirdPhase; //창문의 체력이 바뀌는 세번째 지점 정의
    Vector3 spawnPosition;
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "buildingMover" && count < firstPhase)
        {
            Instantiate(maps[0], spawnPosition, Quaternion.identity);
            count = count + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);
        }
        else if (collider.gameObject.tag == "buildingMover" && count < secondPhase)
        {
            Instantiate(maps[1], spawnPosition, Quaternion.identity);
            count = count + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);
        }
        else if (collider.gameObject.tag == "buildingMover" && count < thirdPhase)
        {
            Instantiate(maps[2], spawnPosition, Quaternion.identity);
            count = count + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);
        }
        else if (collider.gameObject.tag == "buildingMover")
        {
            Instantiate(maps[3], spawnPosition, Quaternion.identity);
            count = count + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);

        }
        else if (collider.gameObject.tag == "mapDestroyer")
        {
            GameObject map = collider.transform.parent.gameObject;
            Destroy(map);

        }
    }
}
