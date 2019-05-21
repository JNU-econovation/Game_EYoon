using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float sideMove;
    [SerializeField] float forwardSpeed;
    [SerializeField] float moveDistance;
    [SerializeField] int NofBullet = 30; // 초기 총알 개수 
    public GameObject[] maps; //소환하려는 맵들
    [SerializeField] int height; //buildingMover와 충돌한 횟수
    [SerializeField] int firstPhase; // 창문의 체력이 바뀌는 첫번째 지점 정의
    [SerializeField] int secondPhase; //창문의 체력이 바뀌는 두번째 지점 정의
    [SerializeField] int thirdPhase; //창문의 체력이 바뀌는 세번째 지점 정의
    [SerializeField] Vector3 spawnPosition;


    void Update()
    {
        transform.Translate(0, forwardSpeed, 0);


        if (Input.GetKey(KeyCode.D) )
        {
            transform.Translate(sideMove*Time.deltaTime, 0, 0);
           
          
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-sideMove*Time.deltaTime, 0, 0);
          
        }
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "buildingMover" && height < firstPhase)
        {
           
            Instantiate(maps[0], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3 (0,moveDistance,0);
           
           
         
        }
       else if (other.gameObject.tag == "buildingMover" && height < secondPhase)
        {
           
            Instantiate(maps[1], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);

        }
        else if (other.gameObject.tag == "buildingMover" && height < thirdPhase)
        {
           
            Instantiate(maps[2], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);

        }
       else if (other.gameObject.tag == "buildingMover")
        {
            
            Instantiate(maps[3], spawnPosition, Quaternion.identity);
            height = height + 1;
            spawnPosition = spawnPosition + new Vector3(0, moveDistance, 0);

        }
        else if (other.gameObject.tag == "mapDestroyer")
        {
            GameObject map = other.transform.parent.gameObject;
            Destroy(map);
  
        }


    }


    
    
  
}
