using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
   [SerializeField] GameObject red;
   [SerializeField] GameObject black;
    public GameObject service;
    GameObject player;
    public bool isTurnOn = false;
    float delay = 0.5f;
    float lifeTime = 3.0f;
    
    void Awake()
    {
        player = service.GetComponent<LevelManager>().player;
    }

    IEnumerator ChangeColor()
    {
       for(int i = 0; i < 3; i++)
        {
            red.SetActive(true);
            black.SetActive(false);
            yield return new WaitForSeconds(delay);
            red.SetActive(false);
            black.SetActive(true);
            yield return new WaitForSeconds(delay);
        }
        gameObject.SetActive(false);

    }
   
    private void OnEnable()
    {
        isTurnOn = true;
        transform.position = new Vector2(Random.Range(335, 385), player.transform.position.y + Random.Range(10, 80));
        StartCoroutine(ChangeColor());
    }

    
}
