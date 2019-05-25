using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilldingMove : MonoBehaviour
{
    [SerializeField] float moveDistance;
    public GameObject[] maps; //소환하려는 맵들
    [SerializeField] int height; //buildingMover와 충돌한 횟수
    [SerializeField] int firstPhase; // 창문의 체력이 바뀌는 첫번째 지점 정의
    [SerializeField] int secondPhase; //창문의 체력이 바뀌는 두번째 지점 정의
    [SerializeField] int thirdPhase; //창문의 체력이 바뀌는 세번째 지점 정의
    [SerializeField] Vector3 spawnPosition;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "buildingMover" && height < firstPhase)
        {
            Instantiate(maps[0], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);
        }
        else if (collider.gameObject.tag == "buildingMover" && height < secondPhase)
        {
            Instantiate(maps[1], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);
        }
        else if (collider.gameObject.tag == "buildingMover" && height < thirdPhase)
        {
            Instantiate(maps[2], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);
        }
        else if (collider.gameObject.tag == "buildingMover")
        {
            Instantiate(maps[3], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);

        }
        else if (collider.gameObject.tag == "mapDestroyer")
        {
            GameObject map = collider.transform.parent.gameObject;
            Destroy(map);

        }
    }
}
