using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    GameObject player;
    GameObject service;

    public float yDistance;
    float x;
    float y;
    float z;

    void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        player = service.GetComponent<LevelManager>().player;
        x = transform.position.x;
        z = transform.position.z;
      //  StartCoroutine(MoveCamera());
    }
  
    void Update()
    {
        y = player.transform.position.y - yDistance;       
        transform.position = new Vector3(x, y, z);    
       
    }

    IEnumerator MoveCamera()
    {
        while (true)
        {
            float cameraXpos = transform.position.x;
            float cameraYpos = transform.position.y;
            float playerXpos = player.transform.position.x;
            Vector2 targetPos = new Vector2(cameraXpos + 30, cameraYpos);
            Vector2 cameraPos = transform.position;
            float diff = cameraXpos - playerXpos;
            if (diff <= -30 || diff >= 30)
            {
                float time = 0.0f;
                float duration = 2.0f;
                while (time < duration)
                {

                    yield return null;
                    transform.position = Vector2.Lerp(cameraPos, targetPos, time / duration);
                    time += Time.deltaTime;
                    
                }

            }
            y = player.transform.position.y - yDistance;       
        transform.position = new Vector3(x, y, z); 

            yield return null;

        }
    }
        
    
}
