using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundCtrl : MonoBehaviour
{
    public GameObject[] backGrounds;
    Vector3 spawnPosition;
    int height = 0;
    public float firstSpanwn;
    public float moveDistance;
    bool Spawnable =  true;
    public float delayTime;

    private void Update()
    {
        spawnPosition = new Vector3(0, height * moveDistance + firstSpanwn, 0);    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "buildingMover" && height <= 10 && Spawnable == true)
        {
            StartCoroutine(LowBackGround());
        }

        else if (other.gameObject.tag == "buildingMover" && height <= 20 && height > 10 && Spawnable == true)
        {
            StartCoroutine(MiddleBackGround());
        }

        else if (other.gameObject.tag == "buildingMover" && height > 20 && Spawnable == true)
        {
            StartCoroutine(HighBackGround());
        }
    }

    IEnumerator LowBackGround()
    {
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Spawnable = false;
        height = height + 1;
        Instantiate(backGrounds[0], spawnPosition, Rotation);
        yield return new WaitForSeconds(delayTime);
        Spawnable = true;
    }

    IEnumerator MiddleBackGround()
    {
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Spawnable = false;
        height = height + 1;
        Instantiate(backGrounds[1], spawnPosition, Rotation);
        yield return new WaitForSeconds(delayTime);
        Spawnable = true;
    }

    IEnumerator HighBackGround()
    {
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Spawnable = false;
        height = height + 1;
        Instantiate(backGrounds[2], spawnPosition, Rotation);
        yield return new WaitForSeconds(delayTime);
        Spawnable = true;
    }
}
