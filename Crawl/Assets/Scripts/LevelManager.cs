using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject playerPrefab;
    GameObject player;
    public GameObject aa;
    public GameObject ab;
    public GameObject ac;
    List<GameObject> a = new List<GameObject>();
    void Awake()
    {
        player = playerPrefab;
        a.Add(aa);
        a.Add(player);
        a.Add(ab);
        a.Add(ac);
        //player = Instantiate(playerPrefab);
    }
    private void Update()
    {
        print(a.Count);
    }
    public GameObject GetPlayer()
    {
        return player;
    }

    IEnumerator e()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(aa);
    }
}
