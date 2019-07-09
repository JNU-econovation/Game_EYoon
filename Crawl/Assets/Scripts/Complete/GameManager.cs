using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coin;
    public GameObject coinItemPrefab;
    void Start()
    {                
    }

    void Update()
    {
        coin = coinItemPrefab.GetComponent<CoinItem>().coin;
    }
}
