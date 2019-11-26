using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bomb_Attack : MonoBehaviour
{
    int num_of_Bomb;
    public GameObject bomb;
    List<GameObject> bomb_List = new List<GameObject>();
    bool isPause;
    public void ThrowBomb(int n)
    {
        num_of_Bomb = n;
        StartCoroutine(MakeBomb());
    }
    IEnumerator MakeBomb()
    {
        for(int i = 0;i < num_of_Bomb; i++)
        {
            GameObject temp = Instantiate(bomb, transform.position, Quaternion.identity);
            bomb_List.Add(temp);
            yield return new WaitForSeconds(1.0f);
        }
    }
    public void Pause()
    {
        for(int i = 0;i< bomb_List.Count; i++)
        {
            if (bomb_List[i] != null)
                bomb_List[i].GetComponent<Bomb>().Pause();
        }
    }
    public void Resume()
    {
        for (int i = 0; i < bomb_List.Count; i++)
        {
            if (bomb_List[i] != null)
                bomb_List[i].GetComponent<Bomb>().Resume();
        }
    }
    
}
